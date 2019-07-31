#ifndef INTERNAL_FILE_OPERATION_INCLUDE
#define INTERNAL_FILE_OPERATION_INCLUDE

#include <cstdio>

#include <CustomFile.h>

#define fopen (FILE*)Dali::Internal::Platform::InternalFile::FOpen

#define fread CustomFile::FRead
#define fwrite CustomFile::FWrite
#define fseek CustomFile::FSeek

#define fclose CustomFile::FClose
#define ftell CustomFile::FTell
#define feof CustomFile::FEof

#define fmemopen (FILE*)CustomFile::FMemopen

namespace Dali
{
namespace Internal
{
namespace Platform
{
namespace InternalFile
{
  FILE* FOpen( const char *name, const char *mode );

  FILE *FMemopen( void *__s, size_t __len, const char *__modes );

  size_t FRead( void*  _Buffer, size_t _ElementSize, size_t _ElementCount, FILE*  _Stream );
  int FClose( FILE *__stream );

  void FWrite( void *buf, int size, int count, FILE *fp );

  int FSeek( FILE *fp, int offset, int origin );

  int FTell( FILE *fp );

  bool FEof( FILE *fp );
}
}
}
}

#endif