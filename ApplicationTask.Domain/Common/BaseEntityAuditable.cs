namespace ApplicationTask.Domain.Common;

public class BaseEntityAuditable
{
    public DateTimeOffset Created { get; set; }

    public DateTimeOffset LastModified { get; set; }

}