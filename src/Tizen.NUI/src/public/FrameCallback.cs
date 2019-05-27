using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tizen.NUI
{
    public class FrameCallback : BaseHandle
    {
        public FrameCallback() : this(Interop.FrameCallback.FrameUpdateCallback_New(), true)
        {

        }

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal FrameCallback(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.FrameCallback.FrameUpdateCallback_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void FrameUpdateCallback(float progress);

        public void AddCallback(FrameUpdateCallback callback)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(callback);
            {
                Interop.FrameCallback.FrameUpdateCallback_AddCallback(swigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void AddMainThreadCallback(FrameUpdateCallback callback)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(callback);
            {
                Interop.FrameCallback.FrameUpdateCallback_AddMainThreadCallback(swigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void RemoveCallback()
        {
            Interop.FrameCallback.FrameUpdateCallback_RemoveCallback(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector3 GetPosition(uint actorID)
        {
            Vector3 ret = new Vector3(Interop.FrameCallback.FrameUpdateCallback_GetPosition(swigCPtr, actorID), false);
            return ret;
        }

        public void SetPosition(uint actorID, Vector3 position)
        {
            Interop.FrameCallback.FrameUpdateCallback_SetPosition(swigCPtr, actorID, Vector3.getCPtr(position));
        }

        public void BakePosition(uint actorID, Vector3 position)
        {
            Interop.FrameCallback.FrameUpdateCallback_BakePosition(swigCPtr, actorID, Vector3.getCPtr(position));
        }

        public Vector3 GetSize(uint actorID)
        {
            Vector3 ret = new Vector3(Interop.FrameCallback.FrameUpdateCallback_GetSize(swigCPtr, actorID), false);
            return ret;
        }

        public void SetSize(uint actorID, Vector3 size)
        {
            Interop.FrameCallback.FrameUpdateCallback_SetSize(swigCPtr, actorID, Vector3.getCPtr(size));
        }

        public void BakeSize(uint actorID, Vector3 size)
        {
            Interop.FrameCallback.FrameUpdateCallback_BakeSize(swigCPtr, actorID, Vector3.getCPtr(size));
        }

        public Vector3 GetScale(uint actorID)
        {
            Vector3 ret = new Vector3(Interop.FrameCallback.FrameUpdateCallback_GetScale(swigCPtr, actorID), false);
            return ret;
        }

        public void SetScale(uint actorID, Vector3 scale)
        {
            Interop.FrameCallback.FrameUpdateCallback_SetScale(swigCPtr, actorID, Vector3.getCPtr(scale));
        }

        public void BakeScale(uint actorID, Vector3 scale)
        {
            Interop.FrameCallback.FrameUpdateCallback_BakeScale(swigCPtr, actorID, Vector3.getCPtr(scale));
        }

        public Vector4 GetColor(uint actorID)
        {
            Vector4 ret = new Vector4(Interop.FrameCallback.FrameUpdateCallback_GetColor(swigCPtr, actorID), false);
            return ret;
        }

        public void SetColor(uint actorID, Vector4 color)
        {
            Interop.FrameCallback.FrameUpdateCallback_SetColor(swigCPtr, actorID, Vector4.getCPtr(color));
        }

        public void BakeColor(uint actorID, Vector4 color)
        {
            Interop.FrameCallback.FrameUpdateCallback_BakeColor(swigCPtr, actorID, Vector4.getCPtr(color));
        }

        public void SetAlphaFunction(AlphaFunction alphaFunction)
        {
            Interop.FrameCallback.FrameUpdateCallback_SetAlphaFunction(swigCPtr, AlphaFunction.getCPtr(alphaFunction));
        }

        public AlphaFunction GetAlphaFunction()
        {
            AlphaFunction alphaFunction = new AlphaFunction(Interop.FrameCallback.FrameUpdateCallback_GetAlphaFunction(swigCPtr), false);
            return alphaFunction;
        }

        public void SetDuration(float seconds)
        {
            Interop.FrameCallback.FrameUpdateCallback_SetDuration(swigCPtr, seconds);
        }

        public float GetDuration()
        {
            return Interop.FrameCallback.FrameUpdateCallback_GetDuration(swigCPtr);
        }

    }
}
