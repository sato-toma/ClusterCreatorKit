using System.IO;
using ClusterVR.CreatorKit.Editor.Api.Venue;
using UnityEditor;
using UnityEngine;

namespace ClusterVR.CreatorKit.Editor.Window.VenueUpload
{
    public static class LocalVenueLockStore
    {
        const string Prefix = "ClusterCreatorKit.LockedVenue.";
        static readonly string ProjectScope = GetProjectScope();

        public static bool IsVenueLocked(Venue venue)
        {
            if (venue == null)
            {
                return false;
            }

            return EditorPrefs.GetBool(GetKey(venue), false);
        }

        public static void SetVenueLocked(Venue venue, bool isLocked)
        {
            if (venue == null)
            {
                return;
            }

            EditorPrefs.SetBool(GetKey(venue), isLocked);
        }

        public static void LockAllVenues(System.Collections.Generic.List<Venue> venues)
        {
            if (venues == null)
            {
                return;
            }

            foreach (var venue in venues)
            {
                SetVenueLocked(venue, true);
            }
        }

        public static void UnlockAllVenues(System.Collections.Generic.List<Venue> venues)
        {
            if (venues == null)
            {
                return;
            }

            foreach (var venue in venues)
            {
                SetVenueLocked(venue, false);
            }
        }

        static string GetKey(Venue venue)
        {
            return $"{Prefix}{ProjectScope}_{venue.VenueId.Value}";
        }

        static string GetProjectScope()
        {
            return Path.GetFullPath(Path.Combine(Application.dataPath, ".."));
        }
    }
}
