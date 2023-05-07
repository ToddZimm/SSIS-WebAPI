// --------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the SQL PLUS Code Generation Utility.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
//     Underlying Query: PackagesById
//     Last Modified On: 5/3/2023 7:52:59 PM
//     Written By: Todd Zimmerman
//     Visit https://www.SQLPLUS.net for more information about the SQL PLUS build time ORM.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------
namespace SSIS.DataService.SSISDB.Models
{
    #nullable enable

    #region usings

    using SqlPlusBase;
    using System.ComponentModel.DataAnnotations;

    #endregion usings

    /// <summary>
    /// Input object for the PackagesById service.
    /// </summary>
    public partial class PackagesByIdInput : ValidInput
    {
        #region Constructors

        /// <summary>
        /// Empty constructor for PackagesByIdInput.
        /// </summary>
        public PackagesByIdInput() { }

        /// <summary>
        /// Parameterized constructor for PackagesByIdInput.
        /// </summary>
        /// <param name="Id">Maps to parameter @Id.</param>
        public PackagesByIdInput(int? Id)
        {
            this.Id = Id;
        }

        #endregion Constructors

        #region Fields

        private int? _Id;
        /// <summary>
        /// Maps to parameter @Id.
        /// </summary>
        [Required]
        public int? Id
        {
            get => _Id;
            set => _Id = value;
        }

        #endregion

    }
}