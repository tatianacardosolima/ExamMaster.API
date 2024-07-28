using Common.Shared.Abstractions;
using Common.Shared.Enums;
using MockExam.Manage.Domain.Mocks.Entities;

namespace MockExam.Manage.Domain.MockExam.Response
{
    public class MockResponse: ResponseBase<Guid>
    {        
        public string Title { get; set; }
        public string Description { get; set; }
        public string KeyWord { get; set; }
        public Access Access { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
