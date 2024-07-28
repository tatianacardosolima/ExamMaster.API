using Common.Shared.Enums;
using Common.Shared.Interfaces;

namespace Common.Shared.Records.Requests
{
    public class MockRequest: IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }        
        public string KeyWord { get; set; }
        public Access Access { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class UpdMockRequest : MockRequest, IRequest
    {
        public Guid Id { get; set; }

    }
}
