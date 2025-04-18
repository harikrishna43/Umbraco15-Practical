export const manifests: Array<UmbExtensionManifest> = [
  {
    name: "Umbraco 15Core Entrypoint",
    alias: "Umbraco15.Core.Entrypoint",
    type: "backofficeEntryPoint",
    js: () => import("./entrypoint"),
  }
];
