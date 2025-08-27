using Bonsai;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

public class GenerateLvpSetBrightnessMessage : GenerateLvpMessage
{
    public byte Brightness { get; set; }

    protected override byte[] CreateDataMessage()
    {
        var dataMessage = base.CreateDataMessage();
        dataMessage[2] = 0x16;
        dataMessage[3] = Brightness;

        return dataMessage;
    }
}