using Bonsai;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

public class GenerateLvpCheckCommunicationMessage : GenerateLvpMessage
{
    protected override byte[] CreateDataMessage()
    {
        var dataMessage = base.CreateDataMessage();
        dataMessage[2] = 0xFE;
        dataMessage[3] = 0xFE;

        return dataMessage;
    }
}