using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using IBGE.Api.Domain.Entities;

namespace IBGE.Api.Application.Models
{
    public class StateModel
    {

        [JsonIgnore]
        [Range(0, byte.MaxValue)]
        public byte StateId { get; private set; }

        [Required]
        [Range(10, byte.MaxValue)]
        public byte Code { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(4, MinimumLength = 2)]
        public string Acronym { get; set; } = null!;

        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        public void AddStateId(byte stateId)
        {
            // Aplicar validações para numeros negativos
            StateId = stateId;
        }

        public State ConvertToState()
        {
            var state = new State(Code, Acronym, Name);

            return state;
        }
    }
}

