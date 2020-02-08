﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_dictionary_value_t.cs
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169

using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using CefNet.WinApi;
using CefNet.CApi;
using CefNet.Internal;

namespace CefNet
{
	/// <summary>
	/// Structure representing a dictionary value. Can be used on any process and
	/// thread.
	/// </summary>
	/// <remarks>
	/// Role: Proxy
	/// </remarks>
	public unsafe partial class CefDictionaryValue : CefBaseRefCounted<cef_dictionary_value_t>
	{
		internal static unsafe CefDictionaryValue Create(IntPtr instance)
		{
			return new CefDictionaryValue((cef_dictionary_value_t*)instance);
		}

		public CefDictionaryValue(cef_dictionary_value_t* instance)
			: base((cef_base_ref_counted_t*)instance)
		{
		}

		/// <summary>
		/// Gets a value indicating whether this object is valid. This object may become invalid if
		/// the underlying data is owned by another object (e.g. list or dictionary)
		/// and that other object is then modified or destroyed. Do not call any other
		/// functions if this property returns false.
		/// </summary>
		public unsafe virtual bool IsValid
		{
			get
			{
				return SafeCall(NativeInstance->IsValid() != 0);
			}
		}

		/// <summary>
		/// Gets a value indicating whether this object is currently owned by another object.
		/// </summary>
		public unsafe virtual bool IsOwned
		{
			get
			{
				return SafeCall(NativeInstance->IsOwned() != 0);
			}
		}

		/// <summary>
		/// Gets a value indicating whether the values of this object are read-only. Some APIs may
		/// expose read-only objects.
		/// </summary>
		public unsafe virtual bool IsReadOnly
		{
			get
			{
				return SafeCall(NativeInstance->IsReadOnly() != 0);
			}
		}

		/// <summary>
		/// Gets the number of values.
		/// </summary>
		public unsafe virtual long Size
		{
			get
			{
				return SafeCall((long)NativeInstance->GetSize());
			}
		}

		/// <summary>
		/// Returns true (1) if this object and |that| object have the same underlying
		/// data. If true (1) modifications to this object will also affect |that|
		/// object and vice-versa.
		/// </summary>
		public unsafe virtual bool IsSame(CefDictionaryValue that)
		{
			return SafeCall(NativeInstance->IsSame((that != null) ? that.GetNativeInstance() : null) != 0);
		}

		/// <summary>
		/// Returns true (1) if this object and |that| object have an equivalent
		/// underlying value but are not necessarily the same object.
		/// </summary>
		public unsafe virtual bool IsEqual(CefDictionaryValue that)
		{
			return SafeCall(NativeInstance->IsEqual((that != null) ? that.GetNativeInstance() : null) != 0);
		}

		/// <summary>
		/// Returns a writable copy of this object. If |exclude_NULL_children| is true
		/// (1) any NULL dictionaries or lists will be excluded from the copy.
		/// </summary>
		public unsafe virtual CefDictionaryValue Copy(bool excludeEmptyChildren)
		{
			return SafeCall(CefDictionaryValue.Wrap(CefDictionaryValue.Create, NativeInstance->Copy(excludeEmptyChildren ? 1 : 0)));
		}

		/// <summary>
		/// Removes all values. Returns true (1) on success.
		/// </summary>
		public unsafe virtual bool Clear()
		{
			return SafeCall(NativeInstance->Clear() != 0);
		}

		/// <summary>
		/// Returns true (1) if the current dictionary has a value for the given key.
		/// </summary>
		public unsafe virtual bool HasKey(string key)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(NativeInstance->HasKey(&cstr0) != 0);
			}
		}

		/// <summary>
		/// Reads all keys for this dictionary into the specified vector.
		/// </summary>
		public unsafe virtual int GetKeys(CefStringList keys)
		{
			return SafeCall(NativeInstance->GetKeys(keys.GetNativeInstance()));
		}

		/// <summary>
		/// Removes the value at the specified key. Returns true (1) is the value was
		/// removed successfully.
		/// </summary>
		public unsafe virtual bool Remove(string key)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(NativeInstance->Remove(&cstr0) != 0);
			}
		}

		/// <summary>
		/// Returns the value type for the specified key.
		/// </summary>
		public unsafe virtual CefValueType GetType(string key)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(NativeInstance->GetType(&cstr0));
			}
		}

		/// <summary>
		/// Returns the value at the specified key. For simple types the returned value
		/// will copy existing data and modifications to the value will not modify this
		/// object. For complex types (binary, dictionary and list) the returned value
		/// will reference existing data and modifications to the value will modify
		/// this object.
		/// </summary>
		public unsafe virtual CefValue GetValue(string key)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(CefValue.Wrap(CefValue.Create, NativeInstance->GetValue(&cstr0)));
			}
		}

		/// <summary>
		/// Returns the value at the specified key as type bool.
		/// </summary>
		public unsafe virtual int GetBool(string key)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(NativeInstance->GetBool(&cstr0));
			}
		}

		/// <summary>
		/// Returns the value at the specified key as type int.
		/// </summary>
		public unsafe virtual int GetInt(string key)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(NativeInstance->GetInt(&cstr0));
			}
		}

		/// <summary>
		/// Returns the value at the specified key as type double.
		/// </summary>
		public unsafe virtual double GetDouble(string key)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(NativeInstance->GetDouble(&cstr0));
			}
		}

		/// <summary>
		/// Returns the value at the specified key as type string.
		/// The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		public unsafe virtual string GetString(string key)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(CefString.ReadAndFree(NativeInstance->GetString(&cstr0)));
			}
		}

		/// <summary>
		/// Returns the value at the specified key as type binary. The returned value
		/// will reference existing data.
		/// </summary>
		public unsafe virtual CefBinaryValue GetBinary(string key)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(CefBinaryValue.Wrap(CefBinaryValue.Create, NativeInstance->GetBinary(&cstr0)));
			}
		}

		/// <summary>
		/// Returns the value at the specified key as type dictionary. The returned
		/// value will reference existing data and modifications to the value will
		/// modify this object.
		/// </summary>
		public unsafe virtual CefDictionaryValue GetDictionary(string key)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(CefDictionaryValue.Wrap(CefDictionaryValue.Create, NativeInstance->GetDictionary(&cstr0)));
			}
		}

		/// <summary>
		/// Returns the value at the specified key as type list. The returned value
		/// will reference existing data and modifications to the value will modify
		/// this object.
		/// </summary>
		public unsafe virtual CefListValue GetList(string key)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(CefListValue.Wrap(CefListValue.Create, NativeInstance->GetList(&cstr0)));
			}
		}

		/// <summary>
		/// Sets the value at the specified key. Returns true (1) if the value was set
		/// successfully. If |value| represents simple data then the underlying data
		/// will be copied and modifications to |value| will not modify this object. If
		/// |value| represents complex data (binary, dictionary or list) then the
		/// underlying data will be referenced and modifications to |value| will modify
		/// this object.
		/// </summary>
		public unsafe virtual bool SetValue(string key, CefValue value)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(NativeInstance->SetValue(&cstr0, (value != null) ? value.GetNativeInstance() : null) != 0);
			}
		}

		/// <summary>
		/// Sets the value at the specified key as type null. Returns true (1) if the
		/// value was set successfully.
		/// </summary>
		public unsafe virtual bool SetNull(string key)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(NativeInstance->SetNull(&cstr0) != 0);
			}
		}

		/// <summary>
		/// Sets the value at the specified key as type bool. Returns true (1) if the
		/// value was set successfully.
		/// </summary>
		public unsafe virtual bool SetBool(string key, bool value)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(NativeInstance->SetBool(&cstr0, value ? 1 : 0) != 0);
			}
		}

		/// <summary>
		/// Sets the value at the specified key as type int. Returns true (1) if the
		/// value was set successfully.
		/// </summary>
		public unsafe virtual bool SetInt(string key, int value)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(NativeInstance->SetInt(&cstr0, value) != 0);
			}
		}

		/// <summary>
		/// Sets the value at the specified key as type double. Returns true (1) if the
		/// value was set successfully.
		/// </summary>
		public unsafe virtual bool SetDouble(string key, double value)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(NativeInstance->SetDouble(&cstr0, value) != 0);
			}
		}

		/// <summary>
		/// Sets the value at the specified key as type string. Returns true (1) if the
		/// value was set successfully.
		/// </summary>
		public unsafe virtual bool SetString(string key, string value)
		{
			fixed (char* s0 = key)
			fixed (char* s1 = value)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				var cstr1 = new cef_string_t { Str = s1, Length = value != null ? value.Length : 0 };
				return SafeCall(NativeInstance->SetString(&cstr0, &cstr1) != 0);
			}
		}

		/// <summary>
		/// Sets the value at the specified key as type binary. Returns true (1) if the
		/// value was set successfully. If |value| is currently owned by another object
		/// then the value will be copied and the |value| reference will not change.
		/// Otherwise, ownership will be transferred to this object and the |value|
		/// reference will be invalidated.
		/// </summary>
		public unsafe virtual bool SetBinary(string key, CefBinaryValue value)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(NativeInstance->SetBinary(&cstr0, (value != null) ? value.GetNativeInstance() : null) != 0);
			}
		}

		/// <summary>
		/// Sets the value at the specified key as type dict. Returns true (1) if the
		/// value was set successfully. If |value| is currently owned by another object
		/// then the value will be copied and the |value| reference will not change.
		/// Otherwise, ownership will be transferred to this object and the |value|
		/// reference will be invalidated.
		/// </summary>
		public unsafe virtual bool SetDictionary(string key, CefDictionaryValue value)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(NativeInstance->SetDictionary(&cstr0, (value != null) ? value.GetNativeInstance() : null) != 0);
			}
		}

		/// <summary>
		/// Sets the value at the specified key as type list. Returns true (1) if the
		/// value was set successfully. If |value| is currently owned by another object
		/// then the value will be copied and the |value| reference will not change.
		/// Otherwise, ownership will be transferred to this object and the |value|
		/// reference will be invalidated.
		/// </summary>
		public unsafe virtual bool SetList(string key, CefListValue value)
		{
			fixed (char* s0 = key)
			{
				var cstr0 = new cef_string_t { Str = s0, Length = key != null ? key.Length : 0 };
				return SafeCall(NativeInstance->SetList(&cstr0, (value != null) ? value.GetNativeInstance() : null) != 0);
			}
		}
	}
}
