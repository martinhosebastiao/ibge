using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using IBGE.Api.Domain.Entities;

namespace IBGE.Api.Application.Models
{
    public class TownModel
    {
        [JsonIgnore]
        [Range(0, int.MaxValue)]
        public short TownId { get; private set; }

        [Required]
        [Range(1, byte.MaxValue)]
        public byte StateCode { get; set; }

        [Required]
        [Range(1000000, int.MaxValue)]
        public int Code { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        public void AddTownId(short townId)
        {
            // Aplicar validações para numeros negativos
            TownId = townId;
        }

        public Town ConvertToTown()
        {
            var town = new Town(StateCode, Code, Name);

            town.AddTownId(TownId);

            return town;
        }
    }
}

