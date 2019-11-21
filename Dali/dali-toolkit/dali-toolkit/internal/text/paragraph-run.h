#ifndef DALI_TOOLKIT_TEXT_PARAGRAPH_RUN_H
#define DALI_TOOLKIT_TEXT_PARAGRAPH_RUN_H

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
#include <dali/public-api/math/vector2.h>

// INTERNAL INCLUDES
#include <dali-toolkit/internal/text/character-run.h>

namespace Dali
{

namespace Toolkit
{

namespace Text
{

/**
 * @brief ParagraphRun
 *
 * In terms of the bidirectional algorithm, a 'paragraph' is understood as a run of characters between Paragraph Separators or appropriate Newline Functions.
 * A 'paragraph' may also be determined by higher-level protocols like a mark-up tag.
 */
struct ParagraphRun
{
  CharacterRun  characterRun; ///< The initial character index within the whole text and the number of characters of the run.
  Size          layoutSize;   ///< The size of the paragraph when is laid-out.
};

} // namespace Text

} // namespace Toolkit

} // namespace Dali

#endif // DALI_TOOLKIT_TEXT_PARAGRAPH_RUN_H
