﻿using Common.Shared.Interfaces;
using Common.Shared.ValueObjects;
using MockExam.Manage.Domain.Mocks.Entities;

namespace MockExam.Manage.Domain.Answers.Requests
{
    public class MockRequest: IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }        
        public string KeyWord { get; set; }
        public Access Access { get; set; }
        public Guid CreatedBy { get; set; }

    }
}
