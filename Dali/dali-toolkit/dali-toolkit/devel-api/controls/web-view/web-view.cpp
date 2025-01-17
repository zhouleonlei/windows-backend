/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
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

// CLASS HEADER
#include <dali-toolkit/devel-api/controls/web-view/web-view.h>

// INTERNAL INCLUDES
#include <dali-toolkit/internal/controls/web-view/web-view-impl.h>

namespace Dali
{

namespace Toolkit
{

WebView::WebView()
{
}

WebView::WebView( const WebView& WebView )
: Control( WebView )
{
}

WebView& WebView::operator=( const WebView& view )
{
  if( &view != this )
  {
    Control::operator=( view );
  }

  return *this;
}

WebView::~WebView()
{
}

WebView WebView::New()
{
  return Internal::WebView::New();
}

WebView WebView::New( const std::string& locale, const std::string& timezoneId )
{
  return Internal::WebView::New( locale, timezoneId );
}

WebView WebView::DownCast( BaseHandle handle )
{
  return Control::DownCast< WebView, Internal::WebView >( handle );
}

void WebView::LoadUrl( const std::string& url )
{
  Dali::Toolkit::GetImpl( *this ).LoadUrl( url );
}

void WebView::LoadHTMLString( const std::string& htmlString )
{
  Dali::Toolkit::GetImpl( *this ).LoadHTMLString( htmlString );
}

void WebView::Reload()
{
  Dali::Toolkit::GetImpl( *this ).Reload();
}

void WebView::StopLoading()
{
  Dali::Toolkit::GetImpl( *this ).StopLoading();
}

void WebView::Suspend()
{
  Dali::Toolkit::GetImpl( *this ).Suspend();
}

void WebView::Resume()
{
  Dali::Toolkit::GetImpl( *this ).Resume();
}

bool WebView::CanGoForward()
{
  return Dali::Toolkit::GetImpl( *this ).CanGoForward();
}

void WebView::GoForward()
{
  Dali::Toolkit::GetImpl( *this ).GoForward();
}

bool WebView::CanGoBack()
{
  return Dali::Toolkit::GetImpl( *this ).CanGoBack();
}

void WebView::GoBack()
{
  Dali::Toolkit::GetImpl( *this ).GoBack();
}

void WebView::EvaluateJavaScript( const std::string& script, std::function< void( const std::string& ) > resultHandler )
{
  Dali::Toolkit::GetImpl( *this ).EvaluateJavaScript( script, resultHandler );
}

void WebView::EvaluateJavaScript( const std::string& script )
{
  Dali::Toolkit::GetImpl( *this ).EvaluateJavaScript( script, nullptr );
}

void WebView::AddJavaScriptMessageHandler( const std::string& exposedObjectName, std::function< void( const std::string& ) > handler )
{
  Dali::Toolkit::GetImpl( *this ).AddJavaScriptMessageHandler( exposedObjectName, handler );
}

void WebView::ClearHistory()
{
  Dali::Toolkit::GetImpl( *this ).ClearHistory();
}

void WebView::ClearCache()
{
  Dali::Toolkit::GetImpl( *this ).ClearCache();
}

void WebView::ClearCookies()
{
  Dali::Toolkit::GetImpl( *this ).ClearCookies();
}

WebView::WebViewPageLoadSignalType& WebView::PageLoadStartedSignal()
{
  return Dali::Toolkit::GetImpl( *this ).PageLoadStartedSignal();
}

WebView::WebViewPageLoadSignalType& WebView::PageLoadFinishedSignal()
{
  return Dali::Toolkit::GetImpl( *this ).PageLoadFinishedSignal();
}

WebView::WebViewPageLoadErrorSignalType& WebView::PageLoadErrorSignal()
{
  return Dali::Toolkit::GetImpl( *this ).PageLoadErrorSignal();
}

WebView::WebView( Internal::WebView& implementation )
: Control( implementation )
{
}

WebView::WebView( Dali::Internal::CustomActor* internal )
: Control( internal )
{
  VerifyCustomActorPointer< Internal::WebView >( internal );
}

} // namespace Toolkit

} // namespace Dali
