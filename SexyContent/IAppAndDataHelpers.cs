﻿using System;
using System.Collections.Generic;
using ToSic.Eav;
using ToSic.Eav.DataSources;
using ToSic.Eav.ValueProvider;
using ToSic.SexyContent.DataSources;
using ToSic.SexyContent.Razor.Helpers;

namespace ToSic.SexyContent
{
    public interface IAppAndDataHelpers
    {
        [Obsolete("This is now obsolete, please use the app-property of the SxcInstance")]
        App App { get; }
        [Obsolete("This is now obsolete, please use the data-property of the SxcInstance")]
        ViewDataSource Data { get; }
        DnnHelper Dnn { get; }

        SxcHelper Sxc { get; }

        /// <summary>
        /// Transform a IEntity to a DynamicEntity as dynamic object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        dynamic AsDynamic(IEntity entity);

        /// <summary>
        /// Makes sure a dynamicEntity could be wrapped in AsDynamic()
        /// </summary>
        /// <param name="dynamicEntity"></param>
        /// <returns></returns>
        dynamic AsDynamic(dynamic dynamicEntity);

        /// <summary>
        /// Returns the value of a KeyValuePair as DynamicEntity
        /// </summary>
        /// <param name="entityKeyValuePair"></param>
        /// <returns></returns>
        dynamic AsDynamic(KeyValuePair<int, IEntity> entityKeyValuePair);

        /// <summary>
        /// In case AsDynamic is used with Data["name"]
        /// </summary>
        /// <returns></returns>
        IEnumerable<dynamic> AsDynamic(IDataStream stream);

        /// <summary>
        /// In case AsDynamic is used with Data["name"].List
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        IEnumerable<dynamic> AsDynamic(IDictionary<int, IEntity> list);

        /// <summary>
        /// Transform a DynamicEntity dynamic object back to a IEntity instance
        /// </summary>
        /// <param name="dynamicEntity"></param>
        /// <returns></returns>
        IEntity AsEntity(dynamic dynamicEntity);

        /// <summary>
        /// Returns a list of DynamicEntities
        /// </summary>
        /// <param name="entities">List of entities</param>
        /// <returns></returns>
        IEnumerable<dynamic> AsDynamic(IEnumerable<IEntity> entities);

        /// <summary>
        /// Create a source with initial stream to attach...
        /// </summary>
        /// <returns></returns>
        T CreateSource<T>(IDataStream inStream);
        IDataSource CreateSource(string typeName = "", IDataSource inSource = null, IValueCollectionProvider configurationProvider = null);
        T CreateSource<T>(IDataSource inSource = null, IValueCollectionProvider configurationProvider = null);

        // 2016-03-02 Removing this from the interface. 
        // It still works in the scripts, but should not be in the interface
		//dynamic Content { get; }
		//dynamic Presentation { get; }
		//dynamic ListContent { get; }
		//dynamic ListPresentation { get; }

        //List<Element> List { get; }
    }
}