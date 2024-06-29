﻿using Xurmo.Common.Application.Messaging;

namespace Xurmo.Modules.Users.Application.Users.UpdateUser;
public sealed record UpdateUserCommand(Guid UserId, string FirstName, string LastName) : ICommand;
