﻿using System;

namespace MaterialDesignThemes.Wpf
{
    internal class SnackbarMessageQueueItem
    {
        public SnackbarMessageQueueItem(object content, TimeSpan duration, object actionContent = null, Action<object> actionHandler = null, object actionArgument = null,
            bool isPromoted = false, bool ignoreDuplicate = false)
        {
            Content = content;
            Duration = duration;
            ActionContent = actionContent;
            ActionHandler = actionHandler;
            ActionArgument = actionArgument;
            IsPromoted = isPromoted;
            IgnoreDuplicate = ignoreDuplicate;
        }

        /// <summary>
        /// The content to be displayed
        /// </summary>
        public object Content { get; }

        /// <summary>
        /// Message show duration.
        /// </summary>
        public TimeSpan Duration { get; }

        /// <summary>
        /// The content for the action button on the snackbar
        /// </summary>
        public object ActionContent { get; }

        /// <summary>
        /// Handler to be invoked when the action button is clicked
        /// </summary>
        public Action<object> ActionHandler { get; }

        /// <summary>
        /// The argument to pass to the <see cref="ActionHandler"/> delegate.
        /// </summary>
        public object ActionArgument { get; }

        /// <summary>
        /// Promote the message, pushing it in front of any message that is not promoted.
        /// </summary>
        public bool IsPromoted { get; }

        /// <summary>
        /// Still display this message even if it is a duplicate.
        /// </summary>
        public bool IgnoreDuplicate { get; }

        /// <summary>
        /// Checks if given item is a duplicate to this
        /// </summary>
        /// <param name="item">Item to check for duplicate</param>
        /// <returns><c>true</c> if given item is a duplicate to this, <c>false</c> otherwise</returns>
        public bool IsDuplicate(SnackbarMessageQueueItem item)
        {
            return !IgnoreDuplicate
                   && Equals(item.Content, Content)
                   && Equals(item.ActionContent, ActionContent);
        }
    }
}
