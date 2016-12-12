﻿using Api.Architecture.Infra.Data.Context.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Api.Architecture.Infra.Data.Models
{
    public abstract class Entity : IObjectState
    {
        public Entity()
        {
            this.Active = true;
            this.Deleted = false;
            this.EditedDate = null;
            this.DeletedDate = null;
            this.CreatedDate = DateTime.Now;
        }

        [NotMapped]
        [XmlIgnore]
        public ObjectState ObjectState { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> EditedDate { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
    }
}
