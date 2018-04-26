﻿using System.Collections.Generic;
using Abp.Authorization;
using Abp.Configuration;

namespace Abp.Web.Common.Tests
{
    public class AbpWebCommonTestModuleSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(
                    "AbpWebCommonTestModule.Test.Setting1",
                    "TestValue1",
                    scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User,
                    settingClientVisibilityProvider:new RequiresAuthenticationSettingClientVisibilityProvider()),

                new SettingDefinition(
                    "AbpWebCommonTestModule.Test.Setting2",
                    "TestValue2",
                    scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User,
                    settingClientVisibilityProvider:new RequiresPermissionSettingClientVisibilityProvider(new SimplePermissionDependency("Permission1")))
            };
        }
    }
}