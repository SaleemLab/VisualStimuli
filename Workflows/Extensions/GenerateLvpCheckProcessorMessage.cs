using Bonsai;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

public class GenerateLvpCheckProcessorMessage : GenerateLvpMessage
{
    public byte StateRequestByte { get; set; }
    protected override byte[] CreateDataMessage()
    {
        var dataMessage = base.CreateDataMessage();
        dataMessage[2] = 0xFE;
        dataMessage[3] = StateRequestByte;

        return dataMessage;
    }
}