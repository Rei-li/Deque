﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Deque
{
    class EmptyDequeException: Exception {
  /// <summary>
  /// Just create the exception
  /// </summary>
  public EmptyDequeException()
    : base() {
  }

  /// <summary>
  /// Create the exception with description
  /// </summary>
  /// <param name="message">Exception description</param>
  public EmptyDequeException(String message)
    : base(message) {
  }

  /// <summary>
  /// Create the exception with description and inner cause
  /// </summary>
  /// <param name="message">Exception description</param>
  /// <param name="innerException">Exception inner cause</param>
  public EmptyDequeException(String message, Exception innerException)
    : base(message, innerException) {
  }

  /// <summary>
  /// Create the exception from serialized data
  /// </summary>
  /// <param name="info">Serialization info</param>
  /// <param name="context">Serialization context</param>
  protected EmptyDequeException(SerializationInfo info, StreamingContext context)
    : base(info, context) {
  }
}
}
