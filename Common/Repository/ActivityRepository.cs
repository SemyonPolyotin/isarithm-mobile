using System;
using System.Collections.Generic;
using Isarithm.Common.Domain;
using Plugin.Settings;

namespace Isarithm.Common.Repository
{
    public static class ActivityRepository
    {
        public static Activity GetActivity(int activityId)
        {
            if (!CrossSettings.Current.Contains($"activity_{activityId}"))
                return null;

            var numRecords = CrossSettings.Current.GetValueOrDefault($"activity_{activityId}_num_records", 0);
            var timeRecords = new List<TimeRecord>(numRecords);
            for (var i = 0; i < numRecords; i++)
            {
                timeRecords[i] = new TimeRecord
                {
                    AngleX = CrossSettings.Current.GetValueOrDefault($"activity_{activityId}_record_{i}_angle_x", 0),
                    AngleY = CrossSettings.Current.GetValueOrDefault($"activity_{activityId}_record_{i}_angle_y", 0),
                    AngleZ = CrossSettings.Current.GetValueOrDefault($"activity_{activityId}_record_{i}_angle_z", 0),
                    AccelerationX =
                        CrossSettings.Current.GetValueOrDefault($"activity_{activityId}_record_{i}_acceleration_x", 0),
                    AccelerationY =
                        CrossSettings.Current.GetValueOrDefault($"activity_{activityId}_record_{i}_acceleration_y", 0),
                    AccelerationZ =
                        CrossSettings.Current.GetValueOrDefault($"activity_{activityId}_record_{i}_acceleration_z", 0)
                };
            }

            return new Activity
            {
                Id = activityId,
                Name = CrossSettings.Current.GetValueOrDefault($"activity_{activityId}_name", ""),
                Tolerance = CrossSettings.Current.GetValueOrDefault($"activity_{activityId}_tolerance", 0),
                CreateDateTime= CrossSettings.Current.GetValueOrDefault($"activity_{activityId}_create_date_time", DateTime.MinValue),
                LastUpdateDateTime = CrossSettings.Current.GetValueOrDefault($"activity_{activityId}_last_update_date_time", DateTime.MinValue),
                TimeRecords = timeRecords
            };
        }

        public static void SetActivity(Activity activity)
        {
            CrossSettings.Current.AddOrUpdateValue($"Activity_{activity.Id}", activity.Id);
            CrossSettings.Current.AddOrUpdateValue($"Activity_{activity.Id}_name", activity.Name);
            CrossSettings.Current.AddOrUpdateValue($"Activity_{activity.Id}_tolerance", activity.Tolerance);
            CrossSettings.Current.AddOrUpdateValue($"Activity_{activity.Id}_create_date_time", activity.CreateDateTime);
            CrossSettings.Current.AddOrUpdateValue($"Activity_{activity.Id}_last_update_date_time",
                activity.LastUpdateDateTime);

            CrossSettings.Current.AddOrUpdateValue($"Activity_{activity.Id}_numRecords", activity.TimeRecords.Count);
            foreach (var timeRecord in activity.TimeRecords)
            {
                CrossSettings.Current.AddOrUpdateValue($"Activity_{activity.Id}_record_{timeRecord.Order}_angle_x",
                    timeRecord.AngleX);
                CrossSettings.Current.AddOrUpdateValue($"Activity_{activity.Id}_record_{timeRecord.Order}_angle_y",
                    timeRecord.AngleY);
                CrossSettings.Current.AddOrUpdateValue($"Activity_{activity.Id}_record_{timeRecord.Order}_angle_z",
                    timeRecord.AngleZ);
                CrossSettings.Current.AddOrUpdateValue(
                    $"Activity_{activity.Id}_record_{timeRecord.Order}_acceleration_x", timeRecord.AccelerationX);
                CrossSettings.Current.AddOrUpdateValue(
                    $"Activity_{activity.Id}_record_{timeRecord.Order}_acceleration_y", timeRecord.AccelerationY);
                CrossSettings.Current.AddOrUpdateValue(
                    $"Activity_{activity.Id}_record_{timeRecord.Order}_acceleration_z", timeRecord.AccelerationZ);
            }
        }
    }
}