﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 30.11.2021 15:23:31
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace TenderDbContext
{
    public partial class CitizenDocumentType {

        public CitizenDocumentType()
        {
            this.CitizenDocuments = new List<CitizenDocument>();
            OnCreated();
        }

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<CitizenDocument> CitizenDocuments { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
