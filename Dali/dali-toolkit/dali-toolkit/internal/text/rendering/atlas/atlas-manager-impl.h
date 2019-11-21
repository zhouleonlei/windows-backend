#ifndef DALI_TOOLKIT_ATLAS_MANAGER_IMPL_H
#define DALI_TOOLKIT_ATLAS_MANAGER_IMPL_H

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
 */


// EXTERNAL INCLUDES
#include <dali/public-api/common/vector-wrapper.h>
#include <dali/public-api/object/base-object.h>

// INTERNAL INCLUDES
#include <dali-toolkit/internal/text/rendering/atlas/atlas-manager.h>

namespace Dali
{

namespace Toolkit
{

class AtlasManager;

} // namespace Toolkit

namespace Toolkit
{

namespace Internal
{

typedef Dali::Vector< Toolkit::AtlasManager::AtlasSlot > slotContainer;

class AtlasManager;
typedef IntrusivePtr<AtlasManager> AtlasManagerPtr;

class AtlasManager : public Dali::BaseObject
{
public:

  typedef uint32_t SizeType;
  typedef SizeType AtlasId;
  typedef SizeType ImageId;

  /**
   * @brief Internal storage of atlas attributes and image upload results
   */
  struct AtlasDescriptor
  {
    Dali::Texture mAtlas;                                                 // atlas image
    Toolkit::AtlasManager::AtlasSize mSize;                             // size of atlas
    Pixel::Format mPixelFormat;                                         // pixel format used by atlas
    PixelData mHorizontalStrip;                                       // Image used to pad upload
    PixelData mVerticalStrip;                                         // Image used to pad upload
    TextureSet mTextureSet;                                             // Texture set used for atlas texture
    SizeType mTotalBlocks;                                              // total number of blocks in atlas
    SizeType mAvailableBlocks;                                          // number of blocks available in atlas
    Dali::Vector< SizeType > mFreeBlocksList;                           // unless there are any previously freed blocks
  };

  struct AtlasSlotDescriptor
  {
    SizeType mCount;                                                    // Reference count for this slot
    SizeType mImageWidth;                                               // Width of image stored
    SizeType mImageHeight;                                              // Height of image stored
    AtlasId mAtlasId;                                                   // Image is stored in this Atlas
    SizeType mBlock;                                                    // Block within atlas used for image
  };

  AtlasManager();

  /**
   * Create a new AtlasManager
   */
  static AtlasManagerPtr New();

  virtual ~AtlasManager();

  /**
   * @copydoc: Toolkit::AtlasManager::CreateAtlas
   */
  AtlasId CreateAtlas( const Toolkit::AtlasManager::AtlasSize& size, Pixel::Format pixelformat );

  /**
   * @copydoc Toolkit::AtlasManager::SetAddPolicy
   */
  void SetAddPolicy( Toolkit::AtlasManager::AddFailPolicy policy );

  /**
   * @copydoc Toolkit::AtlasManager::Add
   */
  bool Add( const PixelData& image,
            Toolkit::AtlasManager::AtlasSlot& slot,
            Toolkit::AtlasManager::AtlasId atlas );

  /**
   * @copydoc Toolkit::AtlasManager::GenerateMeshData
   */
  void GenerateMeshData( ImageId id,
                         const Vector2& position,
                         Toolkit::AtlasManager::Mesh2D& mesh,
                         bool addReference );

  /**
   * @copydoc Toolkit::AtlasManager::Remove
   */
  bool Remove( ImageId id );

  /**
   * @copydoc Toolkit::AtlasManager::GetAtlasContainer
   */
  Dali::Texture GetAtlasContainer( AtlasId atlas ) const;

  /**
   * @copydoc Toolkit::AtlasManager::GetAtlas
   */
  AtlasId GetAtlas( ImageId id ) const;

  /**
   * @copydoc Toolkit::AtlasManager::SetNewAtlasSize
   */
  void SetNewAtlasSize( const Toolkit::AtlasManager::AtlasSize& size );

  /**
   * @copydoc Toolkit::AtlasManager::GetAtlasSize
   */
  const Toolkit::AtlasManager::AtlasSize& GetAtlasSize( AtlasId atlas );

  /**
   * @copydoc Toolkit::AtlasManager::GetBlockSize
   */
  Vector2 GetBlockSize( AtlasId atlas );

  /**
   * @copydoc Toolkit::AtlasManager::GetFreeBlocks
   */
  SizeType GetFreeBlocks( AtlasId atlas ) const;

  /*
   * @copydoc Toolkit::AtlasManager::GetAtlasCount
   */
  SizeType GetAtlasCount() const;

  /**
   * @copydoc Toolkit::AtlasManager::GetPixelFormat
   */
  Pixel::Format GetPixelFormat( AtlasId atlas ) const;

  /**
   * @copydoc Toolkit::AtlasManager::GetMetrics
   */
  void GetMetrics( Toolkit::AtlasManager::Metrics& metrics );

  /**
   * @copydoc Toolkit::AtlasManager::GetTextures
   */
  TextureSet GetTextures( AtlasId atlas ) const;

  /**
   * @copydoc Toolkit::AtlasManager::SetTextures
   */
  void SetTextures( AtlasId atlas, TextureSet& textureSet );

private:

  std::vector< AtlasDescriptor > mAtlasList;            // List of atlases created
  Vector< AtlasSlotDescriptor > mImageList;             // List of bitmaps stored in atlases
  Toolkit::AtlasManager::AtlasSize mNewAtlasSize;       // Atlas size to use in next creation
  Toolkit::AtlasManager::AddFailPolicy mAddFailPolicy;  // Policy for failing to add an Image

  SizeType CheckAtlas( SizeType atlas,
                       SizeType width,
                       SizeType height,
                       Pixel::Format pixelFormat );

  void UploadImage( const PixelData& image,
                    const AtlasSlotDescriptor& desc );

};

} // namespace Internal

inline const Internal::AtlasManager& GetImplementation(const Toolkit::AtlasManager& manager)
{
  DALI_ASSERT_ALWAYS( manager && "AtlasManager handle is empty" );

  const BaseObject& handle = manager.GetBaseObject();

  return static_cast<const Internal::AtlasManager&>(handle);
}

inline Internal::AtlasManager& GetImplementation(Toolkit::AtlasManager& manager)
{
  DALI_ASSERT_ALWAYS( manager && "AtlasManager handle is empty" );

  BaseObject& handle = manager.GetBaseObject();

  return static_cast<Internal::AtlasManager&>(handle);
}

} // namespace Toolkit

} // namespace Dali


 #endif // DALI_TOOLKIT_ATLAS_MANAGER_IMPL_H
