﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: include/capi/cef_command_line_capi.h
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169

using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using CefNet.WinApi;

namespace CefNet.CApi
{
	/// <summary>
	/// Structure used to create and/or parse command line arguments. Arguments with
	/// &apos;--&apos;, &apos;-&apos; and, on Windows, &apos;/&apos; prefixes are considered switches. Switches
	/// will always precede any arguments without switch prefixes. Switches can
	/// optionally have a value specified using the &apos;=&apos; delimiter (e.g.
	/// &quot;-switch=value&quot;). An argument of &quot;--&quot; will terminate switch parsing with all
	/// subsequent tokens, regardless of prefix, being interpreted as non-switch
	/// arguments. Switch names are considered case-insensitive. This structure can
	/// be used before cef_initialize() is called.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe partial struct cef_command_line_t
	{
		/// <summary>
		/// Base structure.
		/// </summary>
		public cef_base_ref_counted_t @base;

		/// <summary>
		/// int (*)(_cef_command_line_t* self)*
		/// </summary>
		public void* is_valid;

		/// <summary>
		/// Returns true (1) if this object is valid. Do not call any other functions
		/// if this function returns false (0).
		/// </summary>
		[NativeName("is_valid")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern int IsValid();

		/// <summary>
		/// int (*)(_cef_command_line_t* self)*
		/// </summary>
		public void* is_read_only;

		/// <summary>
		/// Returns true (1) if the values of this object are read-only. Some APIs may
		/// expose read-only objects.
		/// </summary>
		[NativeName("is_read_only")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern int IsReadOnly();

		/// <summary>
		/// _cef_command_line_t* (*)(_cef_command_line_t* self)*
		/// </summary>
		public void* copy;

		/// <summary>
		/// Returns a writable copy of this object.
		/// </summary>
		[NativeName("copy")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern cef_command_line_t* Copy();

		/// <summary>
		/// void (*)(_cef_command_line_t* self, int argc, const const char** argv)*
		/// </summary>
		public void* init_from_argv;

		/// <summary>
		/// Initialize the command line with the specified |argc| and |argv| values.
		/// The first argument must be the name of the program. This function is only
		/// supported on non-Windows platforms.
		/// </summary>
		[NativeName("init_from_argv")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern void InitFromArgv(int argc, [Immutable]byte** argv);

		/// <summary>
		/// void (*)(_cef_command_line_t* self, const cef_string_t* command_line)*
		/// </summary>
		public void* init_from_string;

		/// <summary>
		/// Initialize the command line with the string returned by calling
		/// GetCommandLineW(). This function is only supported on Windows.
		/// </summary>
		[NativeName("init_from_string")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern void InitFromString([Immutable]cef_string_t* command_line);

		/// <summary>
		/// void (*)(_cef_command_line_t* self)*
		/// </summary>
		public void* reset;

		/// <summary>
		/// Reset the command-line switches and arguments but leave the program
		/// component unchanged.
		/// </summary>
		[NativeName("reset")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern void Reset();

		/// <summary>
		/// void (*)(_cef_command_line_t* self, cef_string_list_t argv)*
		/// </summary>
		public void* get_argv;

		/// <summary>
		/// Retrieve the original command line string as a vector of strings. The argv
		/// array: { program, [(--|-|/)switch[=value]]*, [--], [argument]* }
		/// </summary>
		[NativeName("get_argv")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern void GetArgv(cef_string_list_t argv);

		/// <summary>
		/// cef_string_userfree_t (*)(_cef_command_line_t* self)*
		/// </summary>
		public void* get_command_line_string;

		/// <summary>
		/// Constructs and returns the represented command line string. Use this
		/// function cautiously because quoting behavior is unclear.
		/// The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		[NativeName("get_command_line_string")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern cef_string_userfree_t GetCommandLineString();

		/// <summary>
		/// cef_string_userfree_t (*)(_cef_command_line_t* self)*
		/// </summary>
		public void* get_program;

		/// <summary>
		/// Get the program part of the command line string (the first item).
		/// The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		[NativeName("get_program")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern cef_string_userfree_t GetProgram();

		/// <summary>
		/// void (*)(_cef_command_line_t* self, const cef_string_t* program)*
		/// </summary>
		public void* set_program;

		/// <summary>
		/// Set the program part of the command line string (the first item).
		/// </summary>
		[NativeName("set_program")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern void SetProgram([Immutable]cef_string_t* program);

		/// <summary>
		/// int (*)(_cef_command_line_t* self)*
		/// </summary>
		public void* has_switches;

		/// <summary>
		/// Returns true (1) if the command line has switches.
		/// </summary>
		[NativeName("has_switches")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern int HasSwitches();

		/// <summary>
		/// int (*)(_cef_command_line_t* self, const cef_string_t* name)*
		/// </summary>
		public void* has_switch;

		/// <summary>
		/// Returns true (1) if the command line contains the given switch.
		/// </summary>
		[NativeName("has_switch")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern int HasSwitch([Immutable]cef_string_t* name);

		/// <summary>
		/// cef_string_userfree_t (*)(_cef_command_line_t* self, const cef_string_t* name)*
		/// </summary>
		public void* get_switch_value;

		/// <summary>
		/// Returns the value associated with the given switch. If the switch has no
		/// value or isn&apos;t present this function returns the NULL string.
		/// The resulting string must be freed by calling cef_string_userfree_free().
		/// </summary>
		[NativeName("get_switch_value")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern cef_string_userfree_t GetSwitchValue([Immutable]cef_string_t* name);

		/// <summary>
		/// void (*)(_cef_command_line_t* self, cef_string_map_t switches)*
		/// </summary>
		public void* get_switches;

		/// <summary>
		/// Returns the map of switch names and values. If a switch has no value an
		/// NULL string is returned.
		/// </summary>
		[NativeName("get_switches")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern void GetSwitches(cef_string_map_t switches);

		/// <summary>
		/// void (*)(_cef_command_line_t* self, const cef_string_t* name)*
		/// </summary>
		public void* append_switch;

		/// <summary>
		/// Add a switch to the end of the command line. If the switch has no value
		/// pass an NULL value string.
		/// </summary>
		[NativeName("append_switch")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern void AppendSwitch([Immutable]cef_string_t* name);

		/// <summary>
		/// void (*)(_cef_command_line_t* self, const cef_string_t* name, const cef_string_t* value)*
		/// </summary>
		public void* append_switch_with_value;

		/// <summary>
		/// Add a switch with the specified value to the end of the command line.
		/// </summary>
		[NativeName("append_switch_with_value")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern void AppendSwitchWithValue([Immutable]cef_string_t* name, [Immutable]cef_string_t* value);

		/// <summary>
		/// int (*)(_cef_command_line_t* self)*
		/// </summary>
		public void* has_arguments;

		/// <summary>
		/// True if there are remaining command line arguments.
		/// </summary>
		[NativeName("has_arguments")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern int HasArguments();

		/// <summary>
		/// void (*)(_cef_command_line_t* self, cef_string_list_t arguments)*
		/// </summary>
		public void* get_arguments;

		/// <summary>
		/// Get the remaining command line arguments.
		/// </summary>
		[NativeName("get_arguments")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern void GetArguments(cef_string_list_t arguments);

		/// <summary>
		/// void (*)(_cef_command_line_t* self, const cef_string_t* argument)*
		/// </summary>
		public void* append_argument;

		/// <summary>
		/// Add an argument to the end of the command line.
		/// </summary>
		[NativeName("append_argument")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern void AppendArgument([Immutable]cef_string_t* argument);

		/// <summary>
		/// void (*)(_cef_command_line_t* self, const cef_string_t* wrapper)*
		/// </summary>
		public void* prepend_wrapper;

		/// <summary>
		/// Insert a command before the current command. Common for debuggers, like
		/// &quot;valgrind&quot; or &quot;gdb --args&quot;.
		/// </summary>
		[NativeName("prepend_wrapper")]
		[MethodImpl(MethodImplOptions.ForwardRef)]
		public unsafe extern void PrependWrapper([Immutable]cef_string_t* wrapper);
	}
}
