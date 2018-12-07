using System;
using System.Collections.Generic;
using System.Text;

namespace SharpLib.Win32
{
    static public partial class Const
    {
        public const uint FSCTL_REQUEST_OPLOCK_LEVEL_1 = 0x00090000;
        public const uint FSCTL_REQUEST_OPLOCK_LEVEL_2 = 0x00090004;
        public const uint FSCTL_REQUEST_BATCH_OPLOCK = 0x00090008;
        public const uint FSCTL_OPLOCK_BREAK_ACKNOWLEDGE = 0x0009000c;
        public const uint FSCTL_OPBATCH_ACK_CLOSE_PENDING = 0x00090010;
        public const uint FSCTL_OPLOCK_BREAK_NOTIFY = 0x00090014;
        public const uint FSCTL_LOCK_VOLUME = 0x00090018;
        public const uint FSCTL_UNLOCK_VOLUME = 0x0009001c;
        public const uint FSCTL_DISMOUNT_VOLUME = 0x00090020;
        public const uint FSCTL_IS_VOLUME_MOUNTED = 0x00090028;
        public const uint FSCTL_IS_PATHNAME_VALID = 0x0009002c;
        public const uint FSCTL_MARK_VOLUME_DIRTY = 0x00090030;
        public const uint FSCTL_QUERY_RETRIEVAL_POINTERS = 0x0009003b;
        public const uint FSCTL_GET_COMPRESSION = 0x0009003c;
        public const uint FSCTL_SET_COMPRESSION = 0x00090040;
        public const uint FSCTL_MARK_AS_SYSTEM_HIVE = 0x0009004f;
        public const uint FSCTL_OPLOCK_BREAK_ACK_NO_2 = 0x00090050;
        public const uint FSCTL_INVALIDATE_VOLUMES = 0x00090054;
        public const uint FSCTL_QUERY_FAT_BPB = 0x00090058;
        public const uint FSCTL_REQUEST_FILTER_OPLOCK = 0x0009005c;
        public const uint FSCTL_FILESYSTEM_GET_STATISTICS = 0x00090060;
        public const uint FSCTL_GET_NTFS_VOLUME_DATA = 0x00090064;
        public const uint FSCTL_GET_NTFS_FILE_RECORD = 0x00090068;
        public const uint FSCTL_GET_VOLUME_BITMAP = 0x0009006f;
        public const uint FSCTL_GET_RETRIEVAL_POINTERS = 0x00090073;
        public const uint FSCTL_MOVE_FILE = 0x00090074;
        public const uint FSCTL_IS_VOLUME_DIRTY = 0x00090078;
        public const uint FSCTL_ALLOW_EXTENDED_DASD_IO = 0x00090083;
        public const uint FSCTL_FIND_FILES_BY_SID = 0x0009008f;
        public const uint FSCTL_SET_OBJECT_ID = 0x00090098;
        public const uint FSCTL_GET_OBJECT_ID = 0x0009009c;
        public const uint FSCTL_DELETE_OBJECT_ID = 0x000900a0;
        public const uint FSCTL_SET_REPARSE_POINT = 0x000900a4;
        public const uint FSCTL_GET_REPARSE_POINT = 0x000900a8;
        public const uint FSCTL_DELETE_REPARSE_POINT = 0x000900ac;
        public const uint FSCTL_ENUM_USN_DATA = 0x000900b3;
        public const uint FSCTL_SECURITY_ID_CHECK = 0x000940b7;
        public const uint FSCTL_READ_USN_JOURNAL = 0x000900bb;
        public const uint FSCTL_SET_OBJECT_ID_EXTENDED = 0x000900bc;
        public const uint FSCTL_CREATE_OR_GET_OBJECT_ID = 0x000900c0;
        public const uint FSCTL_SET_SPARSE = 0x000900c4;
        public const uint FSCTL_SET_ZERO_DATA = 0x000980c8;
        public const uint FSCTL_QUERY_ALLOCATED_RANGES = 0x000940cf;
        public const uint FSCTL_SET_ENCRYPTION = 0x000900d7;
        public const uint FSCTL_ENCRYPTION_FSCTL_IO = 0x000900db;
        public const uint FSCTL_WRITE_RAW_ENCRYPTED = 0x000900df;
        public const uint FSCTL_READ_RAW_ENCRYPTED = 0x000900e3;
        public const uint FSCTL_CREATE_USN_JOURNAL = 0x000900e7;
        public const uint FSCTL_READ_FILE_USN_DATA = 0x000900eb;
        public const uint FSCTL_WRITE_USN_CLOSE_RECORD = 0x000900ef;
        public const uint FSCTL_EXTEND_VOLUME = 0x000900f0;
        public const uint FSCTL_QUERY_USN_JOURNAL = 0x000900f4;
        public const uint FSCTL_DELETE_USN_JOURNAL = 0x000900f8;
        public const uint FSCTL_MARK_HANDLE = 0x000900fc;
        public const uint FSCTL_SIS_COPYFILE = 0x00090100;
        public const uint FSCTL_SIS_LINK_FILES = 0x0009c104;
        public const uint FSCTL_HSM_MSG = 0x0009c108;
        public const uint FSCTL_HSM_DATA = 0x0009c113;
        public const uint FSCTL_RECALL_FILE = 0x00090117;
        public const uint FSCTL_READ_FROM_PLEX = 0x0009411e;
        public const uint FSCTL_FILE_PREFETCH = 0x00090120;
    }
}
