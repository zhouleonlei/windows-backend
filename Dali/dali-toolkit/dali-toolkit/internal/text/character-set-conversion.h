#ifndef DALI_TOOLKIT_CHARACTER_SET_CONVERSION_H
#define DALI_TOOLKIT_CHARACTER_SET_CONVERSION_H

/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

// EXTERNAL INCLUDES
#include <stdint.h>
#include <string>

namespace Dali
{

namespace Toolkit
{

namespace Text
{

/**
 * @brief Retrieves the number of bytes of a utf8 character.
 *
 * @param[in] utf8LeadByte The lead byte of the utf8 character.
 *
 * @return The number of bytes of the character.
 */
uint8_t GetUtf8Length( uint8_t utf8LeadByte );

/**
 * @brief Retrieves the number of characters of the text array encoded in UTF8
 *
 * @param[in] utf8 The pointer to the UTF8 array.
 * @param[in] length The length of the UTF8 array.
 *
 * @return The number of characters.
 */
uint32_t GetNumberOfUtf8Characters( const uint8_t* const utf8, uint32_t length );

/**
 * @brief Retrieves the number of bytes needed to encode in UTF8 the given text array encoded in UTF32.
 *
 * @param[in] utf32 The pointer to the UTF32 array.
 * @param[in] numberOfCharacters The number of characters of the UTF32 array.
 *
 * @return The number of bytes.
 */
uint32_t GetNumberOfUtf8Bytes( const uint32_t* const utf32, uint32_t numberOfCharacters );

/**
 * @brief Converts a text array encoded in UTF8 into a text array encoded in UTF32.
 *
 * The @p utf32 buffer needs to be big enough to store all the characters.
 *
 * If the text contains a single 'CR' character or a pair 'CR'+'LF', they are replaced by a 'LF'.
 *
 * @note GetNumberOfUtf8Characters() does not convert 'CR' or 'CR'+'LF' to 'LF' so the return number
 * of characters of that method may be higher than the number of characters returned by this one.
 *
 * @param[in] utf8 The pointer to the UTF8 array.
 * @param[in] length The length of the UTF8 array.
 * @param[out] utf32 The pointer to the UTF32 array.
 *
 * @return The number of characters.
 */
uint32_t Utf8ToUtf32( const uint8_t* const utf8, uint32_t length, uint32_t* utf32 );

/**
 * @brief Converts a text array encoded in UTF32 into a text array encoded in UTF8.
 *
 * The @p utf8 buffer needs to be big enough to store all the characters.
 *
 * @param[in] utf32 The pointer to the UTF32 array.
 * @param[in] numberOfCharacters The number of characters of the UTF32 array.
 * @param[out] utf8 The pointer to the UTF8 array.
 *
 * @return The number of bytes.
 */
uint32_t Utf32ToUtf8( const uint32_t* const utf32, uint32_t numberOfCharacters, uint8_t* utf8 );

/**
 * @brief Converts a text array encoded in UTF32 into a text array encoded in UTF8.
 *
 * @param[in] utf32 The pointer to the UTF32 array.
 * @param[in] numberOfCharacters The number of characters of the UTF32 array.
 * @param[out] utf8 The UTF8 characters will be stored here.
 */
void Utf32ToUtf8( const uint32_t* const utf32, uint32_t numberOfCharacters, std::string& utf8 );

} // namespace Text

} // namespace Toolkit

} // namespace Dali

#endif // DALI_TOOLKIT_CHARACTER_SET_CONVERSION_H
