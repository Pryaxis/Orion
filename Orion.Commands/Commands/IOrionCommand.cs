﻿using System.Collections.Generic;

namespace Orion.Commands.Commands
{
    public interface IOrionCommand
    {
        CommandResult Run();
    }
}