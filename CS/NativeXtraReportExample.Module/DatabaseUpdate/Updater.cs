using System;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Security;
using NativeXtraReportExample.Module.BusinessObjects;

namespace NativeXtraReportExample.Module.DatabaseUpdate {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            if (ObjectSpace.GetObjectsCount(typeof(Task), null) == 0) {
                for (int i = 1; i <= 100; i++) {
                    var task = ObjectSpace.CreateObject<Task>();
                    task.Subject = string.Format("Task #{0:000}", i);
                    task.Deadline = DateTime.Today.AddDays(i - 30);
                }
            }
        }
    }
}
