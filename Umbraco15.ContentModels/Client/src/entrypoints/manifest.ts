export const manifests: Array<UmbExtensionManifest> = [
  {
    name: "Umbraco 15Content Models Entrypoint",
    alias: "Umbraco15.ContentModels.Entrypoint",
    type: "backofficeEntryPoint",
    js: () => import("./entrypoint"),
  }
];
