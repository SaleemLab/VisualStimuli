using Bonsai;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

public class GenerateLvpMessage : Source<byte[]>
{
    public byte DeviceNumber { get; set; }
    public byte ControlledDevice { get; set; }

    protected virtual byte CalculateCheckSum(byte[] message)
    {
        byte checkSum = 0x00;
        foreach (byte b in message)
        {
            checkSum ^= b;
        }

        return checkSum;
    }

    protected virtual byte[] CreateDataMessage()
    {
        byte[] dataMessage = new byte[12];
        Array.Clear(dataMessage, 0, dataMessage.Length);
        dataMessage[0] = DeviceNumber;
        dataMessage[1] = ControlledDevice;
        return dataMessage;
    }

    protected virtual byte[] CreateCheckMessage()
    {
        var dataMessage = CreateDataMessage();
        var checkSum = CalculateCheckSum(dataMessage);

        var checkMessage = dataMessage.Append(checkSum).ToArray();

        return checkMessage;
    }

    public override IObservable<byte[]> Generate()
    {
        return Observable.Return(CreateCheckMessage());
    }
}
