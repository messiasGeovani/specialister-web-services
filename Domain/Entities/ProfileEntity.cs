﻿using Domain.Shared.Models;

namespace Domain.Entities
{
    public class ProfileEntity : BaseEntity
    {
        public string Bio { get; set; }
        public string ImageKey { get; set; }
        public bool? Completed { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public List<ProfileConnectionEntity> Connections { get; set; }
        public List<RatingEntity> ReceivedRatings { get; set; }
        public List<RatingEntity> SentRatings { get; set; }
        public List<MessageEntity> Messages { get; set; }

    }
}
