﻿using SubSonic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observations.Data
{
    public partial class Status : ActiveRecord<Status>, IActiveRecord, IRecordBase
    {
        public const string DateInvalid = "3ccec392-e437-4b45-a2b2-dba4d92a1db5";
        public const string TimeInvalid = "30c1bef8-37a7-4e2f-8930-48a5cdb9a9af";
        public const string OfferingInvalid = "94f865e2-c366-4313-980d-f6ec12d60e83";
        public const string ValueInvalid = "27f857ac-61b0-4c4a-86ab-777246d42e2b";
        public const string TransformValueInvalid = "e9cdf5dc-badb-42fe-92a3-f8f239fb2d7e";
        public const string UOMInvalid = "d9e0289e-02d5-4ee2-8134-8516476aa31a";
        public const string SensorProcedureNotFound = "dda15e09-c652-400e-9111-ebfc192363ff";
        public const string BatchRetracted = "302c69b6-f9d4-4d9f-82bb-a61cfc5dd80b";
    }

}