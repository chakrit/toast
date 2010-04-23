
using System;
using System.Collections.Generic;
using System.IO;

using Fu;
using Fu.Results;

using NHaml;

using Token = Toast.Web.Tokens.Token;

namespace Toast.Web
{
  public class ToastPage : HamlResultBase
  {
    private string _pageName;

    public ToastPage(string pageName)
    {
      _pageName = pageName;
    }


    protected override IEnumerable<string> GetTemplateNames(IFuContext context)
    {
      if (!_pageName.Contains(".")) {
        yield return _pageName + ".haml";
      }
      else {
        yield return _pageName + ".haml";
        yield return _pageName.Substring(0, _pageName.IndexOf('.')) + ".haml";
      }

      yield return "Master.haml";
    }


    protected override Type GetTemplateType(IFuContext context)
    {
      return typeof(ToastTemplate);
    }


    public static ToastPage From(string pageName)
    {
      return new ToastPage(pageName);
    }

    public static ToastPage<T> From<T>(string pageName, T token)
      where T : Token
    {
      return new ToastPage<T>(pageName, token);
    }
  }


  public class ToastPage<T> : ToastPage
    where T : Token
  {
    private T _token;

    public ToastPage(string pageName, T token) :
      base(pageName)
    {
      _token = token;
    }


    protected override Type GetTemplateType(IFuContext context)
    {
      return typeof(ToastTemplate<T>);
    }

    protected override void OnBeforeRender(IFuContext context, Template template)
    {
      // adds token to template before rendering
      var tmpl = (ToastTemplate<T>)template;
      tmpl.Token = _token;
    }
  }
}
