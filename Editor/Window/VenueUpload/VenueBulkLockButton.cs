using System;
using System.Collections.Generic;
using System.Linq;
using ClusterVR.CreatorKit.Editor.Api.Venue;
using ClusterVR.CreatorKit.Translation;
using UnityEngine.UIElements;

namespace ClusterVR.CreatorKit.Editor.Window.VenueUpload
{
    public sealed class VenueBulkLockButton : VisualElement
    {
        public event Action OnBulkLockStateChanged;

        public VenueBulkLockButton(List<Venue> venues)
        {


            var allLocked = venues.All(v => LocalVenueLockStore.IsVenueLocked(v));
            var button = new Button
            {
                text = allLocked ? TranslationTable.cck_unlock_all_venues : TranslationTable.cck_lock_all_venues
            };
            button.clicked += () =>
            {
                if (allLocked)
                {
                    LocalVenueLockStore.UnlockAllVenues(venues);
                }
                else
                {
                    LocalVenueLockStore.LockAllVenues(venues);
                }

                OnBulkLockStateChanged?.Invoke();
            };

            Add(button);
        }
    }
}
