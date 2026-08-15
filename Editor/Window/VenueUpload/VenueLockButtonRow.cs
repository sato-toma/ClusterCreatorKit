using System;
using ClusterVR.CreatorKit.Editor.Api.Venue;
using ClusterVR.CreatorKit.Translation;
using UnityEngine.UIElements;

namespace ClusterVR.CreatorKit.Editor.Window.VenueUpload
{
    public sealed class VenueLockButtonRow : VisualElement
    {
        public event Action OnLockToggled;

        public VenueLockButtonRow(Venue venue)
        {

            var isLocked = LocalVenueLockStore.IsVenueLocked(venue);

            var lockButton = new Button
            {
                text = isLocked ? "🔒" : "🔓",
                tooltip = isLocked ? TranslationTable.cck_unlock_venue : TranslationTable.cck_lock_venue_on_this_machine,
                style = { minWidth = 32, maxWidth = 32, paddingLeft = 4, paddingRight = 4, marginRight = 4 }
            };
            lockButton.clicked += () =>
            {
                var nextLockState = !LocalVenueLockStore.IsVenueLocked(venue);
                LocalVenueLockStore.SetVenueLocked(venue, nextLockState);
                OnLockToggled?.Invoke();
            };

            Add(lockButton);
        }
    }
}
