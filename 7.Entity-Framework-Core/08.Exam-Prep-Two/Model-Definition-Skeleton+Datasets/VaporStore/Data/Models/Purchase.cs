﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public PurchaseType Type { get; set; }

        [Required]
        [RegularExpression("([A-z]*[0-9]*){4}-([A-z]*[0-9]*){4}-([A-z]*[0-9]*){4}")]
        [StringLength(14, MinimumLength = 14)]
        public string ProductKey { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [ForeignKey(nameof(Card))]
        public int CardId { get; set; }

        [Required]
        public Card Card { get; set; }

        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        [Required]
        public Game Game { get; set; }
    }
}