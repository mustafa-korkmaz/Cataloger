﻿using Common.Enumerations;

namespace Common.Response
{
    /// <summary>
    /// abstract response class
    /// </summary>
    public abstract class AbsResponse
    {
        public ResponseCode ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }

    /// <summary>
    /// response class between Controllers and BL classes
    /// </summary>
    public class BLResponse<T> : AbsResponse
    {
        // to do: here goes other properties for BLResponse object

        T responseData;
        public T ResponseData
        {
            get
            {
                return this.responseData;
            }
            set
            {
                this.responseData = value;
            }
        }

    }


}