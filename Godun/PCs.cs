namespace Godun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCs
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(30)]
        public string CPU { get; set; }

        [StringLength(30)]
        public string RAM { get; set; }

        [StringLength(30)]
        public string OZU { get; set; }

        [StringLength(30)]
        public string HDD { get; set; }

        [StringLength(30)]
        public string User { get; set; }

        [StringLength(30)]
        public string OS { get; set; }

        [StringLength(30)]
        public string IP { get; set; }

        [StringLength(30)]
        public string MothersPlate { get; set; }

        public int Org_Id { get; set; }

        public int? IventNumber { get; set; }

        public virtual Organisations Organisations { get; set; }
    }
}
