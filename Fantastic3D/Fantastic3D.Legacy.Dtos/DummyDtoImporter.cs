using System;
using System.Collections.Generic;
using System.Text;

namespace Fantastic3D.Legacy.Dtos
{
    public class DummyDtoImporter : IDtoImporter<AssetDto>
    {
        public void ImportData(List<AssetDto> loadedList)
        {
            var dummyList = new List<AssetDto>()
            {
                new AssetDto(1, "Puffin lowPoly", "A low-poly puffin. How convenient!", 0f, "Atrenor"),
                new AssetDto(2, "Haunted castle", "A haunted castle. How scary!", 0f, "YDaemon"),
                new AssetDto(3, "Saxophone", "A musical instrument called a saxophone. How jazzy!", 0f, "C0untB4s1e"),
                new AssetDto(4, "Pinguin lowPoly", "A low-poly pinguin. Try to test the service on the word 'lowPoly'!", 0f, "Atrenor"),

            };
            loadedList.AddRange(dummyList);
        }
    }
}
