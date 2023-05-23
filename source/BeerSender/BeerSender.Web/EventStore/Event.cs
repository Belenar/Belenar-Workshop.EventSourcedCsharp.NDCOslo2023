using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using BeerSender.Domain.Box.Events;

namespace BeerSender.Web.EventStore;

public sealed class Event
{
    public long Id { get; set; }
    public Guid AggregateId { get; set; }
    public DateTime Timestamp { get; set; }

    [MaxLength(256)]
    public string? PayloadType { get; set; }
    
    public string? Payload { get; set; }
    
    [Timestamp]
    public byte[]? RowVersion { get; set; }

    private IEvent? _WrappedEvent;

    [NotMapped]
    public IEvent WrappedEvent
    {
        get
        {
            if (_WrappedEvent is null && 
                Payload is { } payload &&
                PayloadType is { } payloadType &&
                Type.GetType(payloadType) is { } type)
            {
                _WrappedEvent = JsonSerializer.Deserialize(payload, type) as IEvent;
            }
            if (_WrappedEvent is null)
            {
                throw new InvalidOperationException("WrappedEvent is null");
            }
            return _WrappedEvent;
        }
        set
        {
            _WrappedEvent = value;
            PayloadType = value.GetType().AssemblyQualifiedName;
            Payload = JsonSerializer.Serialize(value);
        }
    }
}