using System;
using System.Collections.Generic;
using System.Text;

namespace Fantastic3D.Legacy.Dtos
{
    /// <summary>
    /// Interface for importing DTOs into Framework-related classes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDtoImporter<T>
        where T : AssetDto
    {
        /// <summary>
        /// Import data for the corresponding DTO class into loadedList.
        /// If data exists for a given instance, it will be overwritten.
        /// </summary>
        /// <param name="loadedList">List in which the data will be populated.</param>
        void ImportData(List<T> loadedList);
    }
}
