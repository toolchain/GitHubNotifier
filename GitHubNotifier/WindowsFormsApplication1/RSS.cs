using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubNotifier
{
    public class RSS
    {
        /// <summary>
        /// A structure to hold items of github commit
        /// </summary>
        [Serializable]
        public struct Items
        {
            /// <summary>
            /// Date of commit
            /// </summary>
            public DateTime Date;

            /// <summary>
            /// Name of commit author
            /// </summary>
            public string AuthorName;

            /// <summary>
            /// Commit message
            /// </summary>
            public string Message;
        }
    }
}
