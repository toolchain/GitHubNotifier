using System;
using System.Xml;
using System.Collections.ObjectModel;
using System.Text;

namespace GitHubNotifier
{
    /// <summary>
    /// XML parsing handler
    /// </summary>
    public class RSSManager : IDisposable
    {
        #region Constants

        private const string errorURLNotSpecified = "You must provide a feed URL";
        private const string feedTitleTag = "title";
        private const string entryTag = "entry";
        private const string dateTag = "updated";
        private const string authorTag = "author";
        private const string messageTag = "title";

        #endregion

        private string _url;
        private string _feedTitle;
        private Collection<RSS.Items> _rssItems = new Collection<RSS.Items>();
        private bool _IsDisposed;

        #region Constructors
        public RSSManager()
        {
            _url = string.Empty;
        }

        public RSSManager(string feedURL)
        {
            _url = feedURL;
        }

        #endregion

        #region Properties

        public string URL
        {
            get { return _url; }
            set { _url = value; }
        }

        public string FeedTitle
        {
            get { return _feedTitle; }
        }

        #endregion

        public Collection<RSS.Items> GetFeed()
        {
            if (String.IsNullOrEmpty(URL))
            {
                throw new ArgumentException(errorURLNotSpecified);
            }

            using (XmlReader reader = XmlReader.Create(URL))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(reader);

                XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName(feedTitleTag);
                _feedTitle = xmlNodeList[0].InnerText;

                ParseRssItems(xmlDoc);

                return _rssItems;
            }
        }

        private void ParseRssItems(XmlDocument xmlDoc)
        {
            _rssItems.Clear();

            XmlNodeList nodes = xmlDoc.GetElementsByTagName(entryTag);

            foreach (XmlNode node in nodes)
            {
                RSS.Items item = new RSS.Items();

                foreach (XmlNode childNode in node.ChildNodes)
                {
                    switch (childNode.Name)
                    {
                        case messageTag:
                            item.Message = childNode.InnerText;
                            break;
                        case dateTag:
                            string date = null;
                            date = childNode.InnerText;
                            DateTime.TryParse(date, out item.Date);
                            break;
                        case authorTag:
                            item.AuthorName = childNode.ChildNodes[0].InnerText;
                            break;
                    }
                }

                _rssItems.Add(item);
            }
        }

        #region IDisposable Members

        private void Dispose(bool disposing)
        {
            if (disposing && !_IsDisposed)
            {
                _rssItems.Clear();
                _url = null;
                _feedTitle = null;
            }

            _IsDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
