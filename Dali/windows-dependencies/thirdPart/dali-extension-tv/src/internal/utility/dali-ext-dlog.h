#ifndef __DALI_EXTENSION_TV_DLOG_H__
#define __DALI_EXTENSION_TV_DLOG_H__

#ifndef TARGET_PROFILE_UBUNTU
#include <dlog.h>
#else
#include <stdio.h>
#endif

namespace DaliExtTV {

#ifdef TARGET_PROFILE_UBUNTU

#define DALIEXT_ERRLOG printf
#define DALIEXT_DBGLOG printf
#define DALIEXT_INFOLOG printf

#else

#ifdef LOG_TAG
#undef LOG_TAG
#endif
#define LOG_TAG "DALI_EXT_TV"

#ifndef DALIEXT_ERRLOG
#define DALIEXT_ERRLOG(fmt,args...) LOGE("[%s:%d] " fmt"\n", __func__, __LINE__, ##args)
#endif

#ifndef DALIEXT_DBGLOG
#define DALIEXT_DBGLOG(fmt, args...) LOGD("[%s:%d] " fmt"\n", __func__, __LINE__, ##args)
#endif

#ifndef DALIEXT_INFOLOG
#define DALIEXT_INFOLOG(fmt, args...) LOGI("[%s:%d] " fmt"\n", __func__, __LINE__, ##args)
#endif

#endif  //TARGET_PROFILE_UBUNTU
}      // namespace DaliExtTV

#endif // __DALI_EXTENSION_TV_DLOG_H__
