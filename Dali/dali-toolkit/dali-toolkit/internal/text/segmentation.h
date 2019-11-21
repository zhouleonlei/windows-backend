#ifndef DALI_TOOLKIT_TEXT_SEGMENTATION_H
#define DALI_TOOLKIT_TEXT_SEGMENTATION_H

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
#include <dali/public-api/common/dali-vector.h>

// INTERNAL INCLUDES
#include <dali-toolkit/internal/text/text-definitions.h>

namespace Dali
{

namespace Toolkit
{

namespace Text
{

class LogicalModel;

/**
 * Sets line break info.
 *
 * Possible values for LineBreakInfo are:
 *
 *  - 0 is a LINE_MUST_BREAK.  Text must be broken into a new line.
 *  - 1 is a LINE_ALLOW_BREAK. Is possible to break the text into a new line.
 *  - 2 is a LINE_NO_BREAK.    Text can't be broken into a new line.
 *
 * @param[in] text Vector of UTF-32 characters.
 * @param[in] startIndex The character from where the break info is set.
 * @param[in] numberOfCharacters The number of characters.
 * @param[out] lineBreakInfo The line break info
 */
void SetLineBreakInfo( const Vector<Character>& text,
                       CharacterIndex startIndex,
                       Length numberOfCharacters,
                       Vector<LineBreakInfo>& lineBreakInfo );

/**
 * Sets word break info.
 *
 * - 0 is a WORD_BREAK.    Text can be broken into a new word.
 * - 1 is a WORD_NO_BREAK. Text can't be broken into a new word.
 *
 * @param[in] text Vector of UTF-32 characters.
 * @param[in] startIndex The character from where the break info is set.
 * @param[in] numberOfCharacters The number of characters.
 * @param[out] wordBreakInfo The word break info.
 */
void SetWordBreakInfo( const Vector<Character>& text,
                       CharacterIndex startIndex,
                       Length numberOfCharacters,
                       Vector<WordBreakInfo>& wordBreakInfo );

} // namespace Text

} // namespace Toolkit

} // namespace Dali

#endif // DALI_TOOLKIT_TEXT_SEGMENTATION_H
