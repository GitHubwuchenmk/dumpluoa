// Namespace: SYBO.Subway.AssetManagement
public enum RequestStatus // TypeDefIndex: 11733
{
	// Fields
	public int value__; // 0x0
	public const RequestStatus Idle = 0;
	public const RequestStatus WaitingForLoadingSlot = 1;
	public const RequestStatus Loading = 2;
	public const RequestStatus Completed = 3;
	public const RequestStatus Failed = 4;
}

// Namespace: SYBO.Subway.AssetManagement
public interface IAssetClient // TypeDefIndex: 11734
{
	// Properties
	public abstract string Identifier { get; set; }
	public abstract object Owner { get; set; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract string get_Identifier();

	// RVA: -1 Offset: -1 Slot: 1
	public abstract void set_Identifier(string value);

	// RVA: -1 Offset: -1 Slot: 2
	public abstract object get_Owner();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract void set_Owner(object value);

	// RVA: -1 Offset: -1 Slot: 4
	public abstract void OnAssetLoadSuccess(AssetRequest request);

	// RVA: -1 Offset: -1 Slot: 5
	public abstract void OnAssetLoadError(AssetRequest request);
}

// Namespace: SYBO.Subway.AssetManagement
public class AssetCompletionQueue // TypeDefIndex: 11735
{
	// Fields
	private List<AssetRequest> _delayedCompletion; // 0x8
	private List<AssetRequest> _regularCompletion; // 0xC
	private List<AssetRequest> _regularUnload; // 0x10
	private List<AssetRequest> _tempDelayedCompletion; // 0x14
	private List<AssetRequest> _tempRegularCompletion; // 0x18
	private List<AssetRequest> _tempRegularUnload; // 0x1C

	// Methods

	// RVA: 0x697E90 Offset: 0x697E90 VA: 0x697E90
	public void RegisterDelayed(AssetRequest request) { }

	// RVA: 0x697F48 Offset: 0x697F48 VA: 0x697F48
	public void RegisterCompletion(AssetRequest request) { }

	// RVA: 0x698000 Offset: 0x698000 VA: 0x698000
	public void RegisterUnload(AssetRequest request) { }

	// RVA: 0x6980B8 Offset: 0x6980B8 VA: 0x6980B8
	public void Process() { }

	// RVA: 0x6986B8 Offset: 0x6986B8 VA: 0x6986B8
	public void .ctor() { }
}

// Namespace: SYBO.Subway.AssetManagement
[SettingsAttribute] // RVA: 0x36F3F8 Offset: 0x36F3F8 VA: 0x36F3F8
[SettingsPresentationAttribute] // RVA: 0x36F3F8 Offset: 0x36F3F8 VA: 0x36F3F8
public class AssetManagerSettings // TypeDefIndex: 11736
{
	// Fields
	public AssetManagerDelaySettings PreLoadDelay; // 0x8
	public AssetManagerDelaySettings PostLoadDelay; // 0xC
	public AssetManagerConcurrencySettings Concurrency; // 0x10

	// Methods

	// RVA: 0x699D44 Offset: 0x699D44 VA: 0x699D44
	public void .ctor() { }
}

// Namespace: SYBO.Subway.AssetManagement
public class AssetManagerConcurrencySettings // TypeDefIndex: 11737
{
	// Fields
	public int MaxAddressablesLoads; // 0x8
	public int MaxExternalLoads; // 0xC

	// Methods

	// RVA: 0x699CCC Offset: 0x699CCC VA: 0x699CCC
	public void .ctor() { }
}

// Namespace: SYBO.Subway.AssetManagement
public class AssetManagerDelaySettings // TypeDefIndex: 11738
{
	// Fields
	public int Min; // 0x8
	public int Max; // 0xC

	// Methods

	// RVA: 0x699CE4 Offset: 0x699CE4 VA: 0x699CE4
	public bool IsValid() { }

	// RVA: 0x699D18 Offset: 0x699D18 VA: 0x699D18
	public int GetDelay() { }

	// RVA: 0x699D2C Offset: 0x699D2C VA: 0x699D2C
	public void .ctor() { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F45C Offset: 0x36F45C VA: 0x36F45C
private struct AssetRequest.<LoadAsync>d__29 : IAsyncStateMachine // TypeDefIndex: 11739
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncVoidMethodBuilder <>t__builder; // 0x4
	public AssetRequest <>4__this; // 0x14
	private TaskAwaiter <>u__1; // 0x18
	private TaskAwaiter<Object> <>u__2; // 0x1C

	// Methods

	// RVA: 0x891764 Offset: 0x891764 VA: 0x891764 Slot: 4
	private void MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BC9DC Offset: 0x3BC9DC VA: 0x3BC9DC
	// RVA: 0x8922EC Offset: 0x8922EC VA: 0x8922EC Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
}

// Namespace: SYBO.Subway.AssetManagement
public abstract class AssetRequest // TypeDefIndex: 11740
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x3AB2B8 Offset: 0x3AB2B8 VA: 0x3AB2B8
	private Object <Asset>k__BackingField; // 0x8
	private List<IAssetClient> _registeredClients; // 0xC
	private List<IAssetClient> _delayedCompletionNotifications; // 0x10
	private AssetCompletionQueue _queue; // 0x14
	private Stopwatch _stopWatch; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x3AB2C8 Offset: 0x3AB2C8 VA: 0x3AB2C8
	private string <AssetId>k__BackingField; // 0x1C
	public RequestStatus Status; // 0x20
	protected Log _logger; // 0x24
	private SemaphoreSlim _semaphore; // 0x28
	private AssetManagerSettings _settings; // 0x2C
	private Task _loadingTask; // 0x30
	private AssetLoadCompletionDataEvent _analyticsEvent; // 0x34

	// Properties
	protected Object Asset { get; set; }
	public string AssetId { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x3BC930 Offset: 0x3BC930 VA: 0x3BC930
	// RVA: 0x69A0DC Offset: 0x69A0DC VA: 0x69A0DC
	protected Object get_Asset() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BC940 Offset: 0x3BC940 VA: 0x3BC940
	// RVA: 0x69A0E4 Offset: 0x69A0E4 VA: 0x69A0E4
	protected void set_Asset(Object value) { }

	// RVA: 0x69A0EC Offset: 0x69A0EC VA: 0x69A0EC
	public List<IAssetClient> GetRegisteredClients() { }

	// RVA: -1 Offset: -1 Slot: 4
	public abstract Type GetAssetType();

	[CompilerGeneratedAttribute] // RVA: 0x3BC950 Offset: 0x3BC950 VA: 0x3BC950
	// RVA: 0x69A0F4 Offset: 0x69A0F4 VA: 0x69A0F4
	public string get_AssetId() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BC960 Offset: 0x3BC960 VA: 0x3BC960
	// RVA: 0x69A0FC Offset: 0x69A0FC VA: 0x69A0FC
	private void set_AssetId(string value) { }

	// RVA: 0x69A104 Offset: 0x69A104 VA: 0x69A104
	protected void .ctor(string assetId, Log logger, SemaphoreSlim semaphore, AssetManagerSettings settings, AssetCompletionQueue queue) { }

	// RVA: 0x69A23C Offset: 0x69A23C VA: 0x69A23C
	public void SetSettings(AssetManagerSettings settings) { }

	// RVA: -1 Offset: -1
	public T GetAsset<T>() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x83E970 Offset: 0x83E970 VA: 0x83E970
	|-AssetRequest.GetAsset<FontAssetConfiguration>
	|-AssetRequest.GetAsset<GameObject>
	|-AssetRequest.GetAsset<object>
	|-AssetRequest.GetAsset<RouteConfig>
	|-AssetRequest.GetAsset<ShaderVariantCollection>
	|-AssetRequest.GetAsset<SpawnVisualsOverride>
	|-AssetRequest.GetAsset<ThemedAssetOverrides>
	*/

	// RVA: 0x69A244 Offset: 0x69A244 VA: 0x69A244
	private void AddClient(IAssetClient client) { }

	// RVA: 0x69A338 Offset: 0x69A338 VA: 0x69A338
	private bool HasClients() { }

	// RVA: 0x6999BC Offset: 0x6999BC VA: 0x6999BC
	internal void RemoveClient(IAssetClient client) { }

	// RVA: 0x69A398 Offset: 0x69A398 VA: 0x69A398
	public void Load(IAssetClient client) { }

	// RVA: 0x69A49C Offset: 0x69A49C VA: 0x69A49C
	private void NotifyLater(IAssetClient client) { }

	// RVA: 0x6983D8 Offset: 0x6983D8 VA: 0x6983D8
	public void NotifyDelayedCompletions() { }

	[AsyncStateMachineAttribute] // RVA: 0x3BC970 Offset: 0x3BC970 VA: 0x3BC970
	// RVA: 0x69A3E0 Offset: 0x69A3E0 VA: 0x69A3E0
	private void LoadAsync() { }

	// RVA: 0x69A56C Offset: 0x69A56C VA: 0x69A56C
	private void OnResolved(Object result) { }

	// RVA: 0x698600 Offset: 0x698600 VA: 0x698600
	public void NotifyCallers() { }

	// RVA: 0x69A7AC Offset: 0x69A7AC VA: 0x69A7AC
	private void OnFailed() { }

	// RVA: 0x69AA88 Offset: 0x69AA88 VA: 0x69AA88
	private void SetStatus(RequestStatus status) { }

	// RVA: 0x69A644 Offset: 0x69A644 VA: 0x69A644
	private void OnSuccess(Object asset) { }

	// RVA: 0x69A914 Offset: 0x69A914 VA: 0x69A914
	private void TryToTrackCompletion(bool result) { }

	// RVA: 0x69AA90 Offset: 0x69AA90 VA: 0x69AA90
	public long GetElapsedTime() { }

	// RVA: 0x69AAB8 Offset: 0x69AAB8 VA: 0x69AAB8 Slot: 5
	protected virtual bool CanBeUnloaded() { }

	// RVA: 0x69865C Offset: 0x69865C VA: 0x69865C
	public void TryToUnload() { }

	// RVA: -1 Offset: -1 Slot: 6
	protected abstract void OnUnload();

	// RVA: -1 Offset: -1 Slot: 7
	public abstract float GetProgress();

	// RVA: -1 Offset: -1 Slot: 8
	protected abstract Task WaitForCompletion();

	// RVA: -1 Offset: -1 Slot: 9
	protected abstract Task<Object> GetResult();

	// RVA: -1 Offset: -1 Slot: 10
	protected abstract string GetIdentifier();
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F46C Offset: 0x36F46C VA: 0x36F46C
private struct ExternalAssetRequest.<GetResult>d__10<T> : IAsyncStateMachine // TypeDefIndex: 11741
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder<Object> <>t__builder; // 0x0
	public ExternalAssetRequest<T> <>4__this; // 0x0
	private byte[] <content>5__2; // 0x0
	private YieldAwaitable.YieldAwaiter <>u__1; // 0x0
	private TaskAwaiter<byte[]> <>u__2; // 0x0
	private Stream <stream>5__3; // 0x0
	private TaskAwaiter <>u__3; // 0x0

	// Methods

	// RVA: -1 Offset: -1 Slot: 4
	private void MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xDBBF14 Offset: 0xDBBF14 VA: 0xDBBF14
	|-ExternalAssetRequest.<GetResult>d__10<object>.MoveNext
	*/

	[DebuggerHiddenAttribute] // RVA: 0x3BCA58 Offset: 0x3BCA58 VA: 0x3BCA58
	// RVA: -1 Offset: -1 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xDBCCC4 Offset: 0xDBCCC4 VA: 0xDBCCC4
	|-ExternalAssetRequest.<GetResult>d__10<object>.SetStateMachine
	*/
}

// Namespace: SYBO.Subway.AssetManagement
public class ExternalAssetRequest<T> : AssetRequest // TypeDefIndex: 11742
{
	// Fields
	private HttpClient _httpClient; // 0x0
	private CancellationTokenSource _cancellationToken; // 0x0
	private Task<HttpResponseMessage> _task; // 0x0
	private Task<Stream> _cacheTask; // 0x0
	private FileStorage _tempStorage; // 0x0
	private byte[] _cachedData; // 0x0
	private string _url; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(string assetId, string url, SemaphoreSlim semaphore, Log logger, AssetManagerSettings settings, HttpClient httpClient, FileStorage tempStorage, AssetCompletionQueue queue) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xF76D48 Offset: 0xF76D48 VA: 0xF76D48
	|-ExternalAssetRequest<object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public override Type GetAssetType() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xF76E10 Offset: 0xF76E10 VA: 0xF76E10
	|-ExternalAssetRequest<object>.GetAssetType
	*/

	// RVA: -1 Offset: -1 Slot: 8
	protected override Task WaitForCompletion() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xF76E94 Offset: 0xF76E94 VA: 0xF76E94
	|-ExternalAssetRequest<object>.WaitForCompletion
	*/

	[AsyncStateMachineAttribute] // RVA: 0x3BC9EC Offset: 0x3BC9EC VA: 0x3BC9EC
	// RVA: -1 Offset: -1 Slot: 9
	protected override Task<Object> GetResult() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xF77284 Offset: 0xF77284 VA: 0xF77284
	|-ExternalAssetRequest<object>.GetResult
	*/

	// RVA: -1 Offset: -1
	private Texture2D GetTextureFromBytes(byte[] bytes) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xF773D8 Offset: 0xF773D8 VA: 0xF773D8
	|-ExternalAssetRequest<object>.GetTextureFromBytes
	*/

	// RVA: -1 Offset: -1 Slot: 6
	protected override void OnUnload() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xF775A4 Offset: 0xF775A4 VA: 0xF775A4
	|-ExternalAssetRequest<object>.OnUnload
	*/

	// RVA: -1 Offset: -1 Slot: 7
	public override float GetProgress() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xF776A8 Offset: 0xF776A8 VA: 0xF776A8
	|-ExternalAssetRequest<object>.GetProgress
	*/

	// RVA: -1 Offset: -1 Slot: 5
	protected override bool CanBeUnloaded() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xF776B0 Offset: 0xF776B0 VA: 0xF776B0
	|-ExternalAssetRequest<object>.CanBeUnloaded
	*/

	// RVA: -1 Offset: -1 Slot: 10
	protected override string GetIdentifier() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xF776C8 Offset: 0xF776C8 VA: 0xF776C8
	|-ExternalAssetRequest<object>.GetIdentifier
	*/
}

// Namespace: SYBO.Subway.AssetManagement
[EasyScriptableObject] // RVA: 0x36F47C Offset: 0x36F47C VA: 0x36F47C
public class FontAssetConfiguration : ScriptableObject // TypeDefIndex: 11743
{
	// Fields
	public TMP_FontAsset[] TMP_FontAssets; // 0xC
	public Font[] Font; // 0x10

	// Methods

	// RVA: 0x971FAC Offset: 0x971FAC VA: 0x971FAC
	public void .ctor() { }
}

// Namespace: SYBO.Subway.AssetManagement
public class SpriteAtlasRequestResolver // TypeDefIndex: 11744
{
	// Fields
	private Dictionary<string, SpriteAtlasRequest> _requests; // 0x8
	private Log _logger; // 0xC

	// Methods

	// RVA: 0x7FAF14 Offset: 0x7FAF14 VA: 0x7FAF14
	public void .ctor(Log logger) { }

	// RVA: 0x7FB104 Offset: 0x7FB104 VA: 0x7FB104
	public void Load(string key) { }

	// RVA: 0x7FB228 Offset: 0x7FB228 VA: 0x7FB228
	private void OnSpriteAtlasRequested(string tag, Action<SpriteAtlas> action) { }
}

// Namespace: SYBO.Subway.AssetManagement
internal class SpriteAtlasRequest // TypeDefIndex: 11745
{
	// Fields
	private List<Action<SpriteAtlas>> _delayedCalls; // 0x8
	private AbstractAssetLoader<SpriteAtlas> _loader; // 0xC
	private SpriteAtlas _atlas; // 0x10
	private Log _logger; // 0x14
	private string _id; // 0x18

	// Methods

	// RVA: 0x7FA938 Offset: 0x7FA938 VA: 0x7FA938
	public void .ctor(string id, Log logger) { }

	// RVA: 0x7FABB4 Offset: 0x7FABB4 VA: 0x7FABB4
	private void OnAssetSuccess(SpriteAtlas atlas) { }

	// RVA: 0x7FAD70 Offset: 0x7FAD70 VA: 0x7FAD70
	private void OnAssetFailed() { }

	// RVA: 0x7FAE10 Offset: 0x7FAE10 VA: 0x7FAE10
	public void Register(Action<SpriteAtlas> action) { }
}

// Namespace: SYBO.Subway.AssetManagement.Analytics
public class AssetLoadCompletionDataEvent : AnalyticsDataEvent // TypeDefIndex: 11746
{
	// Fields
	private const string AssetId = "asset_id";
	private const string Latency = "latency";
	private const string Result = "result";

	// Methods

	// RVA: 0x69881C Offset: 0x69881C VA: 0x69881C
	public void .ctor() { }

	// RVA: 0x6988B4 Offset: 0x6988B4 VA: 0x6988B4
	public AnalyticsDataEvent Configure(string id, bool success, long milliseconds) { }

	// RVA: 0x6989A4 Offset: 0x6989A4 VA: 0x6989A4 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Runtime.Meta
[ExtensionAttribute] // RVA: 0x36F4B0 Offset: 0x36F4B0 VA: 0x36F4B0
public static class CurrencyExtensions // TypeDefIndex: 11747
{
	// Methods

	[ExtensionAttribute] // RVA: 0x3BCA68 Offset: 0x3BCA68 VA: 0x3BCA68
	// RVA: 0x6288EC Offset: 0x6288EC VA: 0x6288EC
	public static bool IsExpirableCurrency(CurrencyType type) { }
}

// Namespace: SYBO.Subway.Runtime.Bootstrap
[ExtensionAttribute] // RVA: 0x36F4C0 Offset: 0x36F4C0 VA: 0x36F4C0
public static class BootstrapExtensionMethods // TypeDefIndex: 11748
{
	// Methods

	[ExtensionAttribute] // RVA: 0x3BCA78 Offset: 0x3BCA78 VA: 0x3BCA78
	// RVA: 0x6C40AC Offset: 0x6C40AC VA: 0x6C40AC
	public static void AddItem(BootstrapListBuilder source, INamedBootstrapExecutable step) { }
}

// Namespace: SYBO.Subway.Runtime.Bootstrap.Shared
public class SharedSceneSetup : MonoBehaviour // TypeDefIndex: 11749
{
	// Fields
	[SerializeField] // RVA: 0x3AB2D8 Offset: 0x3AB2D8 VA: 0x3AB2D8
	private Dropdown[] _dropdownsWidgets; // 0xC
	[SerializeField] // RVA: 0x3AB2E8 Offset: 0x3AB2E8 VA: 0x3AB2E8
	private List<FlyingSpriteSetup> _flyingSpritesSetups; // 0x10
	[SerializeField] // RVA: 0x3AB2F8 Offset: 0x3AB2F8 VA: 0x3AB2F8
	private List<TooltipMapping> _tooltipMapping; // 0x14
	[SerializeField] // RVA: 0x3AB308 Offset: 0x3AB308 VA: 0x3AB308
	private UIColorSchemaCollection _uiSchemas; // 0x18
	[SerializeField] // RVA: 0x3AB318 Offset: 0x3AB318 VA: 0x3AB318
	private TopMenuBar _topBarPrefab; // 0x1C

	// Methods

	// RVA: 0x5BA8C4 Offset: 0x5BA8C4 VA: 0x5BA8C4
	private void Start() { }

	// RVA: 0x5BAA30 Offset: 0x5BAA30 VA: 0x5BAA30
	public void .ctor() { }
}

// Namespace: SYBO.Subway.Runtime.App
public static class AppDataConsentStatus // TypeDefIndex: 11750
{
	// Methods

	// RVA: 0x70E8D0 Offset: 0x70E8D0 VA: 0x70E8D0
	public static bool AnyConsentRequired() { }

	// RVA: 0x70E900 Offset: 0x70E900 VA: 0x70E900
	public static bool AgeGateRequired() { }

	// RVA: 0x70E9D4 Offset: 0x70E9D4 VA: 0x70E9D4
	public static bool DataHandlingRequired() { }

	// RVA: 0x70E9D8 Offset: 0x70E9D8 VA: 0x70E9D8
	public static bool AttHandlingRequired() { }

	// RVA: 0x70E948 Offset: 0x70E948 VA: 0x70E948
	public static bool DataConsentRequired() { }
}

// Namespace: SYBO.Subway.Runtime.App.Settings
[SettingsPresentationAttribute] // RVA: 0x36F4D0 Offset: 0x36F4D0 VA: 0x36F4D0
[SettingsAttribute] // RVA: 0x36F4D0 Offset: 0x36F4D0 VA: 0x36F4D0
public class AppUserAttributionDebugSettings // TypeDefIndex: 11751
{
	// Fields
	public Dictionary<string, string> DebugStrings; // 0x8

	// Methods

	// RVA: 0x697450 Offset: 0x697450 VA: 0x697450
	public void .ctor() { }
}

// Namespace: SYBO.Subway.App
public class AppCore // TypeDefIndex: 11752
{
	// Fields
	public static readonly AppCore Instance; // 0x0
	public static bool EncryptionSupported; // 0x4
	public static string DeviceName; // 0x8
	public static string Version; // 0xC
	public static string Platform; // 0x10
	public AppStorageSpace StorageSpace; // 0x8
	public AppLanguage Language; // 0xC
	public AppNativeDialog NativeDialog; // 0x10
	public AppNativeStoreManager NativeStoreManager; // 0x14
	public AppUserAttribution UserAttribution; // 0x18
	private AppNetwork _network; // 0x1C
	private AppTime _time; // 0x20
	private AppMemory _memory; // 0x24
	public AppLifeCycle LifeCycle; // 0x28
	private static string _persistentPath; // 0x14
	private static string _streamingAssetsPath; // 0x18
	private static string _tempCachePath; // 0x1C
	private static string _dataPath; // 0x20

	// Properties
	public static AppTime Time { get; }
	public static AppNetwork Network { get; }
	public static string PersistentPath { get; }
	public static string StreamingAssetsPath { get; }
	public static string TempCachePath { get; }
	public static string DataPath { get; }

	// Methods

	// RVA: 0x70D784 Offset: 0x70D784 VA: 0x70D784
	public static AppTime get_Time() { }

	// RVA: 0x70D808 Offset: 0x70D808 VA: 0x70D808
	public static AppNetwork get_Network() { }

	// RVA: 0x70D88C Offset: 0x70D88C VA: 0x70D88C
	public static string get_PersistentPath() { }

	// RVA: 0x70D978 Offset: 0x70D978 VA: 0x70D978
	public static string get_StreamingAssetsPath() { }

	// RVA: 0x70DA64 Offset: 0x70DA64 VA: 0x70DA64
	public static string get_TempCachePath() { }

	// RVA: 0x7055FC Offset: 0x7055FC VA: 0x7055FC
	public static string get_DataPath() { }

	// RVA: 0x70DB50 Offset: 0x70DB50 VA: 0x70DB50
	private void .ctor() { }

	// RVA: 0x70E3A8 Offset: 0x70E3A8 VA: 0x70E3A8
	private void OnNetworkChanged(bool status) { }

	// RVA: 0x70E448 Offset: 0x70E448 VA: 0x70E448
	public void Initialize(GameObject gameObject) { }

	// RVA: 0x70E5C4 Offset: 0x70E5C4 VA: 0x70E5C4
	private static void .cctor() { }
}

// Namespace: SYBO.Subway.App
public class AppCoreLoader : MonoBehaviour // TypeDefIndex: 11753
{
	// Fields
	private AppCore _appCore; // 0xC
	private AppManagers _managers; // 0x10

	// Methods

	// RVA: 0x70E638 Offset: 0x70E638 VA: 0x70E638
	private void Awake() { }

	// RVA: 0x70E808 Offset: 0x70E808 VA: 0x70E808
	private void Update() { }

	// RVA: 0x70E8C8 Offset: 0x70E8C8 VA: 0x70E8C8
	public void .ctor() { }
}

// Namespace: SYBO.Subway.App
public class AppEmail // TypeDefIndex: 11754
{
	// Fields
	private string _emailAddress; // 0x8
	private string _subject; // 0xC
	private List<string> _bodyEntries; // 0x10

	// Methods

	// RVA: 0x70E9E0 Offset: 0x70E9E0 VA: 0x70E9E0
	public void .ctor() { }

	// RVA: 0x70EA70 Offset: 0x70EA70 VA: 0x70EA70
	public AppEmail SetAddress(string address) { }

	// RVA: 0x70EAF4 Offset: 0x70EAF4 VA: 0x70EAF4
	public AppEmail SetSubject(string subject) { }

	// RVA: 0x70EB78 Offset: 0x70EB78 VA: 0x70EB78
	public AppEmail AddToBody(string key) { }

	// RVA: 0x70EC14 Offset: 0x70EC14 VA: 0x70EC14
	public AppEmail AddToBreakLineToBody() { }

	// RVA: 0x70ECA0 Offset: 0x70ECA0 VA: 0x70ECA0
	public AppEmail AddToBody(string key, string value) { }

	// RVA: 0x70ED4C Offset: 0x70ED4C VA: 0x70ED4C
	public void Send() { }
}

// Namespace: SYBO.Subway.App
public class AppLanguage // TypeDefIndex: 11755
{
	// Fields
	public static string[] AvailableLanguages; // 0x0
	public const string FallbackLanguage = "en";
	public const string FallbackRegion = "us";
	private const string ChineseSpeaking = "zh";
	private const string ChineseFallback = "zh_CN";
	private const char Underscore = '\x5f';
	private const char Separator = '\x2d';
	public CultureInfo DeviceCultureInfo; // 0x8
	public string DeviceRegion; // 0xC
	private static Dictionary<string, string> JavaDeprecatedCodes; // 0x4

	// Methods

	// RVA: 0x70DF04 Offset: 0x70DF04 VA: 0x70DF04
	public void .ctor() { }

	// RVA: 0x70F20C Offset: 0x70F20C VA: 0x70F20C
	private CultureInfo GetLanguageFromDevice() { }

	// RVA: 0x70F81C Offset: 0x70F81C VA: 0x70F81C
	private CultureInfo GetCultureInfo(SystemLanguage language) { }

	// RVA: 0x70F3B0 Offset: 0x70F3B0 VA: 0x70F3B0
	private CultureInfo GetCultureInfo(string language) { }

	// RVA: 0x70FC3C Offset: 0x70FC3C VA: 0x70FC3C
	private string Sanitize(string baseValue) { }

	// RVA: 0x70FE8C Offset: 0x70FE8C VA: 0x70FE8C
	private string SanitizeChinese(string baseValue) { }

	// RVA: 0x70F700 Offset: 0x70F700 VA: 0x70F700
	private string GetLanguage() { }

	// RVA: 0x70F294 Offset: 0x70F294 VA: 0x70F294
	private string GetLanguageID() { }

	// RVA: 0x7100B8 Offset: 0x7100B8 VA: 0x7100B8
	private static void .cctor() { }
}

// Namespace: SYBO.Subway.App
public class AppLegacyLoggers // TypeDefIndex: 11756
{
	// Fields
	private static AppLegacyLoggers _instance; // 0x0
	public Log Localization; // 0x8
	public Log Ads; // 0xC
	public Log Singletons; // 0x10
	public Log UI; // 0x14
	public Log UnityCollections; // 0x18
	public Log AnimationEvents; // 0x1C
	public Log Utilities; // 0x20
	public Log Validation; // 0x24
	public Log Meta; // 0x28
	public Log PoolManager; // 0x2C
	public Log Json; // 0x30
	public Log EditorExtensions; // 0x34

	// Properties
	public static AppLegacyLoggers Instance { get; }

	// Methods

	// RVA: 0x7056E8 Offset: 0x7056E8 VA: 0x7056E8
	public static AppLegacyLoggers get_Instance() { }

	// RVA: 0x710968 Offset: 0x710968 VA: 0x710968
	public void .ctor() { }
}

// Namespace: SYBO.Subway.App
public class AppLifeCycle : MonoBehaviour // TypeDefIndex: 11757
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x3AB328 Offset: 0x3AB328 VA: 0x3AB328
	private Action OnApplicationQuitEvent; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x3AB338 Offset: 0x3AB338 VA: 0x3AB338
	private Action<bool> OnApplicationFocusEvent; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x3AB348 Offset: 0x3AB348 VA: 0x3AB348
	private Action<bool> OnApplicationPauseEvent; // 0x14

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x3BCA88 Offset: 0x3BCA88 VA: 0x3BCA88
	// RVA: 0x6F90BC Offset: 0x6F90BC VA: 0x6F90BC
	public void add_OnApplicationQuitEvent(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x3BCA98 Offset: 0x3BCA98 VA: 0x3BCA98
	// RVA: 0x6FAAE0 Offset: 0x6FAAE0 VA: 0x6FAAE0
	public void remove_OnApplicationQuitEvent(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x3BCAA8 Offset: 0x3BCAA8 VA: 0x3BCAA8
	// RVA: 0x710D8C Offset: 0x710D8C VA: 0x710D8C
	public void add_OnApplicationFocusEvent(Action<bool> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x3BCAB8 Offset: 0x3BCAB8 VA: 0x3BCAB8
	// RVA: 0x710E38 Offset: 0x710E38 VA: 0x710E38
	public void remove_OnApplicationFocusEvent(Action<bool> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x3BCAC8 Offset: 0x3BCAC8 VA: 0x3BCAC8
	// RVA: 0x710EE4 Offset: 0x710EE4 VA: 0x710EE4
	public void add_OnApplicationPauseEvent(Action<bool> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x3BCAD8 Offset: 0x3BCAD8 VA: 0x3BCAD8
	// RVA: 0x710F90 Offset: 0x710F90 VA: 0x710F90
	public void remove_OnApplicationPauseEvent(Action<bool> value) { }

	// RVA: 0x71103C Offset: 0x71103C VA: 0x71103C
	public void Awake() { }

	// RVA: 0x711048 Offset: 0x711048 VA: 0x711048
	private void OnApplicationQuit() { }

	// RVA: 0x7111B4 Offset: 0x7111B4 VA: 0x7111B4
	private void OnApplicationFocus(bool focus) { }

	// RVA: 0x711378 Offset: 0x711378 VA: 0x711378
	private void OnApplicationPause(bool pause) { }

	// RVA: 0x71153C Offset: 0x71153C VA: 0x71153C
	public void .ctor() { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F548 Offset: 0x36F548 VA: 0x36F548
private struct AppMemory.<OnLowMemory>d__2 : IAsyncStateMachine // TypeDefIndex: 11758
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncVoidMethodBuilder <>t__builder; // 0x4
	public AppMemory <>4__this; // 0x14
	private AsyncOperation <operation>5__2; // 0x18
	private YieldAwaitable.YieldAwaiter <>u__1; // 0x1C

	// Methods

	// RVA: 0x890978 Offset: 0x890978 VA: 0x890978 Slot: 4
	private void MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BCB54 Offset: 0x3BCB54 VA: 0x3BCB54
	// RVA: 0x890D28 Offset: 0x890D28 VA: 0x890D28 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
}

// Namespace: SYBO.Subway.App
public class AppMemory // TypeDefIndex: 11759
{
	// Fields
	private bool _memoryCleanUpInProgress; // 0x8

	// Methods

	// RVA: 0x6916B8 Offset: 0x6916B8 VA: 0x6916B8
	public void Initialize() { }

	[AsyncStateMachineAttribute] // RVA: 0x3BCAE8 Offset: 0x3BCAE8 VA: 0x3BCAE8
	// RVA: 0x6918AC Offset: 0x6918AC VA: 0x6918AC
	private void OnLowMemory() { }

	// RVA: 0x691968 Offset: 0x691968 VA: 0x691968
	private void OnApplicationQuit() { }

	// RVA: 0x691B5C Offset: 0x691B5C VA: 0x691B5C
	public void .ctor() { }
}

// Namespace: SYBO.Subway.App
public class AppNativeDialog // TypeDefIndex: 11760
{
	// Methods

	// RVA: 0x691B64 Offset: 0x691B64 VA: 0x691B64
	public void ShowAlert(string title, string body, string confirmLabel, Action callback) { }

	// RVA: 0x691C80 Offset: 0x691C80 VA: 0x691C80
	public void .ctor() { }
}

// Namespace: SYBO.Subway.App
public class AppNativeStoreManager // TypeDefIndex: 11761
{
	// Fields
	private const string TermsOfService = "https://sybogames.com/terms-of-service/";
	private const string PrivacyPolicy = "https://sybogames.com/privacy-policy/";
	private const string Support = "https://sybo.zendesk.com/";
	private AbstractStoreImplementation _implementation; // 0x8

	// Methods

	// RVA: 0x691C88 Offset: 0x691C88 VA: 0x691C88
	public void .ctor() { }

	// RVA: 0x691CF8 Offset: 0x691CF8 VA: 0x691CF8
	public string GetTermsAndConditionsUrl() { }

	// RVA: 0x691D88 Offset: 0x691D88 VA: 0x691D88
	public string GetPrivacyPolicyUrl() { }

	// RVA: 0x691E18 Offset: 0x691E18 VA: 0x691E18
	public string GetSupportUrl() { }

	// RVA: 0x691EA8 Offset: 0x691EA8 VA: 0x691EA8
	public void OpenStore() { }

	// RVA: 0x691ED8 Offset: 0x691ED8 VA: 0x691ED8
	public void OpenForReview() { }
}

// Namespace: SYBO.Subway.App
internal abstract class AbstractStoreImplementation // TypeDefIndex: 11762
{
	// Methods

	// RVA: -1 Offset: -1 Slot: 4
	public abstract void OpenStore();

	// RVA: -1 Offset: -1 Slot: 5
	public abstract void OpenForReview();

	// RVA: -1 Offset: -1 Slot: 6
	public abstract bool HasAvailableUpdate();

	// RVA: -1 Offset: -1 Slot: 7
	public abstract void StartUpdate();

	// RVA: 0x9A24DC Offset: 0x9A24DC VA: 0x9A24DC
	protected void OpenURL(string key, string fallback) { }

	// RVA: 0x9A2524 Offset: 0x9A2524 VA: 0x9A2524
	protected void .ctor() { }
}

// Namespace: SYBO.Subway.App
internal class EditorStoreImplementation : AbstractStoreImplementation // TypeDefIndex: 11763
{
	// Methods

	// RVA: 0x616734 Offset: 0x616734 VA: 0x616734 Slot: 4
	public override void OpenStore() { }

	// RVA: 0x616738 Offset: 0x616738 VA: 0x616738 Slot: 5
	public override void OpenForReview() { }

	// RVA: 0x61673C Offset: 0x61673C VA: 0x61673C Slot: 6
	public override bool HasAvailableUpdate() { }

	// RVA: 0x616744 Offset: 0x616744 VA: 0x616744 Slot: 7
	public override void StartUpdate() { }

	// RVA: 0x616748 Offset: 0x616748 VA: 0x616748
	public void .ctor() { }
}

// Namespace: SYBO.Subway.App
internal class GoogleStoreImplementation : AbstractStoreImplementation // TypeDefIndex: 11764
{
	// Fields
	private const string GoogleStoreUrl = "https://play.google.com/store/apps/details?id=com.kiloo.subwaysurf";
	private const string GoogleReviewUrl = "market://details?id=com.kiloo.subwaysurf";

	// Methods

	// RVA: 0x596904 Offset: 0x596904 VA: 0x596904
	public void .ctor() { }

	// RVA: 0x59690C Offset: 0x59690C VA: 0x59690C Slot: 4
	public override void OpenStore() { }

	// RVA: 0x596988 Offset: 0x596988 VA: 0x596988 Slot: 5
	public override void OpenForReview() { }

	// RVA: 0x596A04 Offset: 0x596A04 VA: 0x596A04 Slot: 6
	public override bool HasAvailableUpdate() { }

	// RVA: 0x596A0C Offset: 0x596A0C VA: 0x596A0C Slot: 7
	public override void StartUpdate() { }
}

// Namespace: SYBO.Subway.App
internal class IOSStoreImplementation : AbstractStoreImplementation // TypeDefIndex: 11765
{
	// Fields
	private const string IosStoreUrl = "http://itunes.apple.com/app/subway-surfers/id512939461";
	private const string IosReviewUrl = "itms-apps://itunes.apple.com/app/id512939461";

	// Methods

	// RVA: 0xA2FA08 Offset: 0xA2FA08 VA: 0xA2FA08 Slot: 4
	public override void OpenStore() { }

	// RVA: 0xA2FA84 Offset: 0xA2FA84 VA: 0xA2FA84 Slot: 5
	public override void OpenForReview() { }

	// RVA: 0xA2FA88 Offset: 0xA2FA88 VA: 0xA2FA88 Slot: 6
	public override bool HasAvailableUpdate() { }

	// RVA: 0xA2FA90 Offset: 0xA2FA90 VA: 0xA2FA90 Slot: 7
	public override void StartUpdate() { }

	// RVA: 0xA2FA94 Offset: 0xA2FA94 VA: 0xA2FA94
	public void .ctor() { }
}

// Namespace: SYBO.Subway.App
internal class AmazonStoreImplementation : AbstractStoreImplementation // TypeDefIndex: 11766
{
	// Fields
	private const string AmazonReviewUrl = "http://www.amazon.com/review/create-review/ref=cm_cr_dp_wrt_btm?ie=UTF8&asin=B009UX2YAC";
	private const string AmazonStoreUrl = "http://www.amazon.com/gp/mas/dl/android?p=com.kiloo.subwaysurf";

	// Methods

	// RVA: 0x6F56D8 Offset: 0x6F56D8 VA: 0x6F56D8 Slot: 4
	public override void OpenStore() { }

	// RVA: 0x6F5754 Offset: 0x6F5754 VA: 0x6F5754 Slot: 5
	public override void OpenForReview() { }

	// RVA: 0x6F57D0 Offset: 0x6F57D0 VA: 0x6F57D0 Slot: 6
	public override bool HasAvailableUpdate() { }

	// RVA: 0x6F57D8 Offset: 0x6F57D8 VA: 0x6F57D8 Slot: 7
	public override void StartUpdate() { }

	// RVA: 0x6F57DC Offset: 0x6F57DC VA: 0x6F57DC
	public void .ctor() { }
}

// Namespace: SYBO.Subway.App
public class AppStorageSpace // TypeDefIndex: 11767
{
	// Fields
	private static string[] Suffixes; // 0x0
	private const long MinimumStorageSpaceInBytes = 100000000;
	private const long MbInBytes = 1048576;
	private Dictionary<string, string> _warningHeadersPerCulture; // 0x8
	private Dictionary<string, string> _warningBodiesPerCulture; // 0xC
	private Dictionary<string, string> _warningConfirmLabelPerCulture; // 0x10

	// Methods

	// RVA: 0x693BF4 Offset: 0x693BF4 VA: 0x693BF4
	public void .ctor() { }

	// RVA: 0x695070 Offset: 0x695070 VA: 0x695070
	public long GetAvailableSpaceInBytes() { }

	// RVA: 0x695094 Offset: 0x695094 VA: 0x695094
	public bool CanWrite(long bytes) { }

	// RVA: 0x6950E0 Offset: 0x6950E0 VA: 0x6950E0
	public bool HasMinimumSpace() { }

	// RVA: 0x695104 Offset: 0x695104 VA: 0x695104
	public string GetWarningHeader(CultureInfo cultureInfo) { }

	// RVA: 0x695280 Offset: 0x695280 VA: 0x695280
	public string GetConfirmLabel(CultureInfo cultureInfo) { }

	// RVA: 0x69528C Offset: 0x69528C VA: 0x69528C
	public string GetWarningBody(CultureInfo cultureInfo) { }

	// RVA: 0x695110 Offset: 0x695110 VA: 0x695110
	private string GetLabel(Dictionary<string, string> dictionary, CultureInfo cultureInfo) { }

	// RVA: 0x695298 Offset: 0x695298 VA: 0x695298
	public string GetFormattedAvailableSpace() { }

	// RVA: 0x695328 Offset: 0x695328 VA: 0x695328
	public static string GetFormattedBytes(long bytes) { }

	// RVA: 0x69550C Offset: 0x69550C VA: 0x69550C
	private static void .cctor() { }
}

// Namespace: SYBO.Subway.App
public class AppTime // TypeDefIndex: 11768
{
	// Fields
	private AppServerTime _serverTime; // 0x8
	private AppClientTime _clientTime; // 0xC
	private long _appStartTime; // 0x10

	// Properties
	public DateTime ServerTime { get; }
	public DateTime ClientTime { get; }
	public DateTime ClientLocalTime { get; }
	public DateTime ClientToday { get; }
	public AppClientTime Client { get; }
	public long ClientUnixTime { get; }
	public long ClientUnixToday { get; }

	// Methods

	// RVA: 0x6957A0 Offset: 0x6957A0 VA: 0x6957A0
	public void .ctor() { }

	// RVA: 0x695950 Offset: 0x695950 VA: 0x695950
	public void Initialize() { }

	// RVA: 0x695978 Offset: 0x695978 VA: 0x695978
	public long GetAppElapsedTime() { }

	// RVA: 0x695998 Offset: 0x695998 VA: 0x695998
	public DateTime get_ServerTime() { }

	// RVA: 0x6959D4 Offset: 0x6959D4 VA: 0x6959D4
	public DateTime get_ClientTime() { }

	// RVA: 0x695A14 Offset: 0x695A14 VA: 0x695A14
	public DateTime get_ClientLocalTime() { }

	// RVA: 0x695A7C Offset: 0x695A7C VA: 0x695A7C
	public DateTime get_ClientToday() { }

	// RVA: 0x695ABC Offset: 0x695ABC VA: 0x695ABC
	public AppClientTime get_Client() { }

	// RVA: 0x69584C Offset: 0x69584C VA: 0x69584C
	public long get_ClientUnixTime() { }

	// RVA: 0x695AC4 Offset: 0x695AC4 VA: 0x695AC4
	public long get_ClientUnixToday() { }

	// RVA: 0x695BC8 Offset: 0x695BC8 VA: 0x695BC8
	public DateTime FromUnixTime(long unixTime) { }
}

// Namespace: SYBO.Subway.App
public class AppClientTime // TypeDefIndex: 11769
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x3AB358 Offset: 0x3AB358 VA: 0x3AB358
	private Action OnTimeChanged; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x3AB368 Offset: 0x3AB368 VA: 0x3AB368
	private IDateTimeClock <Clock>k__BackingField; // 0xC
	private FileStorage _storage; // 0x10
	private Log _logger; // 0x14

	// Properties
	public DateTime Now { get; }
	public DateTime Today { get; }
	internal IDateTimeClock Clock { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x3BCB64 Offset: 0x3BCB64 VA: 0x3BCB64
	// RVA: 0x70D484 Offset: 0x70D484 VA: 0x70D484
	public void add_OnTimeChanged(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x3BCB74 Offset: 0x3BCB74 VA: 0x3BCB74
	// RVA: 0x70D530 Offset: 0x70D530 VA: 0x70D530
	public void remove_OnTimeChanged(Action value) { }

	// RVA: 0x70D5DC Offset: 0x70D5DC VA: 0x70D5DC
	public DateTime get_Now() { }

	// RVA: 0x70D6BC Offset: 0x70D6BC VA: 0x70D6BC
	public DateTime get_Today() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BCB84 Offset: 0x3BCB84 VA: 0x3BCB84
	// RVA: 0x70D704 Offset: 0x70D704 VA: 0x70D704
	internal IDateTimeClock get_Clock() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BCB94 Offset: 0x3BCB94 VA: 0x3BCB94
	// RVA: 0x70D70C Offset: 0x70D70C VA: 0x70D70C
	internal void set_Clock(IDateTimeClock value) { }

	// RVA: 0x70D714 Offset: 0x70D714 VA: 0x70D714
	internal void .ctor() { }
}

// Namespace: SYBO.Subway.App
internal class AppServerTime // TypeDefIndex: 11770
{
	// Fields
	private readonly object _updateLockObject; // 0x8
	private readonly object _getLockObject; // 0xC
	private int _nowCacheTicks; // 0x10
	private DateTime _nowCache; // 0x18
	private DateTime _lastServerTime; // 0x20
	private DateTime _lastSyncTime; // 0x28
	private AppClientTime _clientTime; // 0x30
	private AppNetwork _network; // 0x34

	// Properties
	public DateTime ServerTime { get; }

	// Methods

	// RVA: 0x692750 Offset: 0x692750 VA: 0x692750
	public void Initialize(AppClientTime clientTime) { }

	// RVA: 0x6929F4 Offset: 0x6929F4 VA: 0x6929F4
	private void OnNetworkChanged(bool value) { }

	// RVA: 0x692900 Offset: 0x692900 VA: 0x692900
	private void SetServerTime(DateTime serverTime) { }

	// RVA: 0x692A6C Offset: 0x692A6C VA: 0x692A6C
	public DateTime get_ServerTime() { }

	// RVA: 0x692AB0 Offset: 0x692AB0 VA: 0x692AB0
	private void UpdateCachedTime() { }

	// RVA: 0x692C78 Offset: 0x692C78 VA: 0x692C78
	public void .ctor() { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F558 Offset: 0x36F558 VA: 0x36F558
private struct AppUserAttribution.<OpenUrl>d__15 : IAsyncStateMachine // TypeDefIndex: 11771
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder<bool> <>t__builder; // 0x4
	public string schema; // 0x10
	private TaskAwaiter<bool> <>u__1; // 0x14

	// Methods

	// RVA: 0x890F64 Offset: 0x890F64 VA: 0x890F64 Slot: 4
	private void MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BCC30 Offset: 0x3BCC30 VA: 0x3BCC30
	// RVA: 0x8911D8 Offset: 0x8911D8 VA: 0x8911D8 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
}

// Namespace: SYBO.Subway.App
public class AppUserAttribution // TypeDefIndex: 11772
{
	// Fields
	private const string PlayerPrefsDidRegister = "did_register";
	private const string FirebaseStatusDisabledEventName = "firebase_disabled";
	private const string FirebaseStatusParamName = "status";
	private const string SingularPassThroughKey = "_p";
	private Log _logger; // 0x8
	private Dictionary<string, string> _attributionData; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x3AB378 Offset: 0x3AB378 VA: 0x3AB378
	private Action OnAttributionReceived; // 0x10

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x3BCBA4 Offset: 0x3BCBA4 VA: 0x3BCBA4
	// RVA: 0x695EE4 Offset: 0x695EE4 VA: 0x695EE4
	public void add_OnAttributionReceived(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x3BCBB4 Offset: 0x3BCBB4 VA: 0x3BCBB4
	// RVA: 0x695F90 Offset: 0x695F90 VA: 0x695F90
	public void remove_OnAttributionReceived(Action value) { }

	// RVA: 0x69603C Offset: 0x69603C VA: 0x69603C
	public void .ctor() { }

	// RVA: 0x69611C Offset: 0x69611C VA: 0x69611C
	public void Initialize() { }

	// RVA: 0x696938 Offset: 0x696938 VA: 0x696938
	private void OnTokenReceived(object sender, TokenReceivedEventArgs token) { }

	// RVA: 0x696A30 Offset: 0x696A30 VA: 0x696A30
	private void OnNetworkChanged(bool status) { }

	// RVA: 0x6963F4 Offset: 0x6963F4 VA: 0x6963F4
	private void TryToInitialize() { }

	// RVA: 0x697014 Offset: 0x697014 VA: 0x697014
	public bool CanOpenUrl(string schema) { }

	[AsyncStateMachineAttribute] // RVA: 0x3BCBC4 Offset: 0x3BCBC4 VA: 0x3BCBC4
	// RVA: 0x69708C Offset: 0x69708C VA: 0x69708C
	public Task<bool> OpenUrl(string schema) { }

	// RVA: 0x6971EC Offset: 0x6971EC VA: 0x6971EC
	public void SetUserConsent(bool consent) { }

	// RVA: 0x697290 Offset: 0x697290 VA: 0x697290
	public void FakeTrigger(Dictionary<string, string> data) { }

	// RVA: 0x6972B4 Offset: 0x6972B4 VA: 0x6972B4
	private void ClearAttributionData() { }

	// RVA: 0x696A3C Offset: 0x696A3C VA: 0x696A3C
	private void OnUserAttributionDataReceived(Dictionary<string, string> data) { }

	// RVA: 0x697338 Offset: 0x697338 VA: 0x697338
	public void RegisterToAttributionReceived(Action callback) { }

	// RVA: 0x697378 Offset: 0x697378 VA: 0x697378
	public bool HasAttribution(string key) { }

	// RVA: 0x6973E8 Offset: 0x6973E8 VA: 0x6973E8
	public void ClearAttribution(string key) { }

	// RVA: -1 Offset: -1
	public bool TryGetAttribution<T>(string key, out T value) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xAD02C4 Offset: 0xAD02C4 VA: 0xAD02C4
	|-AppUserAttribution.TryGetAttribution<object>
	|-AppUserAttribution.TryGetAttribution<string>
	*/
}

// Namespace: SYBO.Subway.App
public abstract class AbstractNetworkCheck // TypeDefIndex: 11773
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x3AB388 Offset: 0x3AB388 VA: 0x3AB388
	private Action<bool> OnChanged; // 0x8

	// Properties
	public abstract bool IsAvailable { get; }
	public abstract bool WasEverAvailable { get; }
	public abstract NetworkStatus CurrentNetworkStatus { get; }
	public abstract DateTime ServerTime { get; }
	public abstract bool HasServerTime { get; }
	public abstract int LastInternetCheckTimeMS { get; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x3BCC40 Offset: 0x3BCC40 VA: 0x3BCC40
	// RVA: 0x9A1BA8 Offset: 0x9A1BA8 VA: 0x9A1BA8
	public void add_OnChanged(Action<bool> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x3BCC50 Offset: 0x3BCC50 VA: 0x3BCC50
	// RVA: 0x9A1C54 Offset: 0x9A1C54 VA: 0x9A1C54
	public void remove_OnChanged(Action<bool> value) { }

	// RVA: -1 Offset: -1 Slot: 4
	public abstract void Initialize(HttpClient httpClient, Log log);

	// RVA: -1 Offset: -1 Slot: 5
	public abstract bool get_IsAvailable();

	// RVA: -1 Offset: -1 Slot: 6
	public abstract bool get_WasEverAvailable();

	// RVA: -1 Offset: -1 Slot: 7
	public abstract NetworkStatus get_CurrentNetworkStatus();

	// RVA: -1 Offset: -1 Slot: 8
	public abstract DateTime get_ServerTime();

	// RVA: -1 Offset: -1 Slot: 9
	public abstract bool get_HasServerTime();

	// RVA: -1 Offset: -1 Slot: 10
	public abstract int get_LastInternetCheckTimeMS();

	// RVA: -1 Offset: -1 Slot: 11
	public abstract Task<bool> ScheduleInternetConnectionCheck();

	// RVA: 0x9A1D00 Offset: 0x9A1D00 VA: 0x9A1D00
	protected void NotifyChange(bool value) { }

	// RVA: 0x9A1D6C Offset: 0x9A1D6C VA: 0x9A1D6C
	protected void .ctor() { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F568 Offset: 0x36F568 VA: 0x36F568
private struct AppNetwork.<FireInternetConnectionCheck>d__27 : IAsyncStateMachine // TypeDefIndex: 11774
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncVoidMethodBuilder <>t__builder; // 0x4
	public AppNetwork <>4__this; // 0x14
	private TaskAwaiter<bool> <>u__1; // 0x18

	// Methods

	// RVA: 0x890D34 Offset: 0x890D34 VA: 0x890D34 Slot: 4
	private void MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BCCEC Offset: 0x3BCCEC VA: 0x3BCCEC
	// RVA: 0x890F58 Offset: 0x890F58 VA: 0x890F58 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
}

// Namespace: SYBO.Subway.App
public class AppNetwork // TypeDefIndex: 11775
{
	// Fields
	private const string ClientVersionHeader = "Client-Version";
	private const int HttpClientTimeout = 10000;
	private AbstractNetworkCheck _check; // 0x8
	private Log _logger; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x3AB398 Offset: 0x3AB398 VA: 0x3AB398
	private HttpClient <HttpClient>k__BackingField; // 0x10

	// Properties
	public HttpClient HttpClient { get; set; }
	public bool IsCompletelyOffline { get; }
	public bool IsAvailable { get; }
	public int LastInternetCheckTimeMS { get; }
	public bool WasEverAvailable { get; }
	public NetworkStatus CurrentNetworkStatus { get; }
	public DateTime ServerTime { get; }
	public bool HasServerTime { get; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x3BCC60 Offset: 0x3BCC60 VA: 0x3BCC60
	// RVA: 0x691F08 Offset: 0x691F08 VA: 0x691F08
	public HttpClient get_HttpClient() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BCC70 Offset: 0x3BCC70 VA: 0x3BCC70
	// RVA: 0x691F10 Offset: 0x691F10 VA: 0x691F10
	private void set_HttpClient(HttpClient value) { }

	// RVA: 0x691F18 Offset: 0x691F18 VA: 0x691F18
	public void .ctor() { }

	// RVA: 0x692224 Offset: 0x692224 VA: 0x692224
	public void add_OnChanged(Action<bool> value) { }

	// RVA: 0x692238 Offset: 0x692238 VA: 0x692238
	public void remove_OnChanged(Action<bool> value) { }

	// RVA: 0x69224C Offset: 0x69224C VA: 0x69224C
	public bool get_IsCompletelyOffline() { }

	// RVA: 0x69229C Offset: 0x69229C VA: 0x69229C
	public bool get_IsAvailable() { }

	// RVA: 0x6922BC Offset: 0x6922BC VA: 0x6922BC
	public int get_LastInternetCheckTimeMS() { }

	// RVA: 0x69227C Offset: 0x69227C VA: 0x69227C
	public bool get_WasEverAvailable() { }

	// RVA: 0x6922DC Offset: 0x6922DC VA: 0x6922DC
	public NetworkStatus get_CurrentNetworkStatus() { }

	// RVA: 0x6922FC Offset: 0x6922FC VA: 0x6922FC
	public DateTime get_ServerTime() { }

	// RVA: 0x6923AC Offset: 0x6923AC VA: 0x6923AC
	public bool get_HasServerTime() { }

	// RVA: 0x6923CC Offset: 0x6923CC VA: 0x6923CC
	public void Initialize() { }

	[AsyncStateMachineAttribute] // RVA: 0x3BCC80 Offset: 0x3BCC80 VA: 0x3BCC80
	// RVA: 0x6925E0 Offset: 0x6925E0 VA: 0x6925E0
	public void FireInternetConnectionCheck() { }

	// RVA: 0x69269C Offset: 0x69269C VA: 0x69269C
	public Task<bool> ScheduleInternetConnectionCheck() { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F578 Offset: 0x36F578 VA: 0x36F578
private struct HttpClientNetworkCheck.<HandleApplicationPause>d__37 : IAsyncStateMachine // TypeDefIndex: 11776
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncVoidMethodBuilder <>t__builder; // 0x4
	public HttpClientNetworkCheck <>4__this; // 0x14
	public bool onFocus; // 0x18
	private TaskAwaiter<bool> <>u__1; // 0x1C

	// Methods

	// RVA: 0x776EEC Offset: 0x776EEC VA: 0x776EEC Slot: 4
	private void MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BCE80 Offset: 0x3BCE80 VA: 0x3BCE80
	// RVA: 0x7771C0 Offset: 0x7771C0 VA: 0x7771C0 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F588 Offset: 0x36F588 VA: 0x36F588
private struct HttpClientNetworkCheck.<PollNetworkReachability>d__38 : IAsyncStateMachine // TypeDefIndex: 11777
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder <>t__builder; // 0x4
	public HttpClientNetworkCheck <>4__this; // 0x10
	private int <expBackOff>5__2; // 0x14
	private TaskAwaiter<bool> <>u__1; // 0x18
	private TaskAwaiter <>u__2; // 0x1C

	// Methods

	// RVA: 0x7771CC Offset: 0x7771CC VA: 0x7771CC Slot: 4
	private void MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BCE90 Offset: 0x3BCE90 VA: 0x3BCE90
	// RVA: 0x777940 Offset: 0x777940 VA: 0x777940 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F598 Offset: 0x36F598 VA: 0x36F598
private struct HttpClientNetworkCheck.<UpdateNetworkReachability>d__40 : IAsyncStateMachine // TypeDefIndex: 11778
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder<bool> <>t__builder; // 0x4
	public HttpClientNetworkCheck <>4__this; // 0x10
	public CancellationToken token; // 0x14
	private YieldAwaitable.YieldAwaiter <>u__1; // 0x18
	private HttpResponseMessage <result>5__2; // 0x1C
	private TaskAwaiter<HttpResponseMessage> <>u__2; // 0x20
	private TaskAwaiter <>u__3; // 0x24

	// Methods

	// RVA: 0x77794C Offset: 0x77794C VA: 0x77794C Slot: 4
	private void MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BCEA0 Offset: 0x3BCEA0 VA: 0x3BCEA0
	// RVA: 0x778310 Offset: 0x778310 VA: 0x778310 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F5A8 Offset: 0x36F5A8 VA: 0x36F5A8
private sealed class HttpClientNetworkCheck.<>c__DisplayClass41_0 // TypeDefIndex: 11779
{
	// Fields
	public HttpClientNetworkCheck <>4__this; // 0x8
	public bool status; // 0xC

	// Methods

	// RVA: 0x776D60 Offset: 0x776D60 VA: 0x776D60
	public void .ctor() { }

	// RVA: 0x776D68 Offset: 0x776D68 VA: 0x776D68
	internal void <NotifyAvailabilityChanged>b__0() { }
}

// Namespace: SYBO.Subway.App
public class HttpClientNetworkCheck : AbstractNetworkCheck // TypeDefIndex: 11780
{
	// Fields
	private const string PollingSite = "https://subway.prod.sybo.net/";
	private const int PollTimeDelayMilliseconds = 15000;
	private const int NoNetworkRecovery = 3000;
	private readonly object _syncLock; // 0xC
	private CancellationTokenSource _cancellationTokenSource; // 0x10
	private CancellationTokenSource _cancellationTokenSourceFocus; // 0x14
	private TaskScheduler _mainThreadScheduler; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x3AB3A8 Offset: 0x3AB3A8 VA: 0x3AB3A8
	private HttpClient <_httpClient>k__BackingField; // 0x1C
	private bool _isAvailable; // 0x20
	private bool _wasEverAvailable; // 0x21
	private bool _paused; // 0x22
	private int _lastNetworkCheckMS; // 0x24
	private Stopwatch _stopwatch; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x3AB3B8 Offset: 0x3AB3B8 VA: 0x3AB3B8
	private Task<bool> <NetworkUpdateTask>k__BackingField; // 0x2C
	private DateTime _lastServerTime; // 0x30
	private bool _hasServerTime; // 0x38

	// Properties
	private HttpClient _httpClient { get; set; }
	private Task<bool> NetworkUpdateTask { get; set; }
	public override int LastInternetCheckTimeMS { get; }
	public override NetworkStatus CurrentNetworkStatus { get; }
	public override DateTime ServerTime { get; }
	public override bool HasServerTime { get; }
	public override bool IsAvailable { get; }
	public override bool WasEverAvailable { get; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x3BCCFC Offset: 0x3BCCFC VA: 0x3BCCFC
	// RVA: 0x5A14BC Offset: 0x5A14BC VA: 0x5A14BC
	private HttpClient get__httpClient() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BCD0C Offset: 0x3BCD0C VA: 0x3BCD0C
	// RVA: 0x5A14C4 Offset: 0x5A14C4 VA: 0x5A14C4
	private void set__httpClient(HttpClient value) { }

	[CompilerGeneratedAttribute] // RVA: 0x3BCD1C Offset: 0x3BCD1C VA: 0x3BCD1C
	// RVA: 0x5A14CC Offset: 0x5A14CC VA: 0x5A14CC
	private Task<bool> get_NetworkUpdateTask() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BCD2C Offset: 0x3BCD2C VA: 0x3BCD2C
	// RVA: 0x5A14D4 Offset: 0x5A14D4 VA: 0x5A14D4
	private void set_NetworkUpdateTask(Task<bool> value) { }

	// RVA: 0x5A14DC Offset: 0x5A14DC VA: 0x5A14DC Slot: 10
	public override int get_LastInternetCheckTimeMS() { }

	// RVA: 0x5A14E4 Offset: 0x5A14E4 VA: 0x5A14E4 Slot: 7
	public override NetworkStatus get_CurrentNetworkStatus() { }

	// RVA: 0x5A1514 Offset: 0x5A1514 VA: 0x5A1514 Slot: 8
	public override DateTime get_ServerTime() { }

	// RVA: 0x5A1520 Offset: 0x5A1520 VA: 0x5A1520 Slot: 9
	public override bool get_HasServerTime() { }

	// RVA: 0x5A1528 Offset: 0x5A1528 VA: 0x5A1528 Slot: 5
	public override bool get_IsAvailable() { }

	// RVA: 0x5A15EC Offset: 0x5A15EC VA: 0x5A15EC Slot: 6
	public override bool get_WasEverAvailable() { }

	// RVA: 0x5A15F4 Offset: 0x5A15F4 VA: 0x5A15F4
	private void SetAvailableAs(bool value) { }

	// RVA: 0x5A18B0 Offset: 0x5A18B0 VA: 0x5A18B0 Slot: 4
	public override void Initialize(HttpClient httpClient, Log log) { }

	// RVA: 0x5A1DA4 Offset: 0x5A1DA4 VA: 0x5A1DA4
	private void HandleApplicationQuit() { }

	[AsyncStateMachineAttribute] // RVA: 0x3BCD3C Offset: 0x3BCD3C VA: 0x3BCD3C
	// RVA: 0x5A2040 Offset: 0x5A2040 VA: 0x5A2040
	private void HandleApplicationPause(bool onFocus) { }

	[AsyncStateMachineAttribute] // RVA: 0x3BCDA8 Offset: 0x3BCDA8 VA: 0x3BCDA8
	// RVA: 0x5A2110 Offset: 0x5A2110 VA: 0x5A2110
	private Task PollNetworkReachability() { }

	// RVA: 0x5A2234 Offset: 0x5A2234 VA: 0x5A2234 Slot: 11
	public override Task<bool> ScheduleInternetConnectionCheck() { }

	[AsyncStateMachineAttribute] // RVA: 0x3BCE14 Offset: 0x3BCE14 VA: 0x3BCE14
	// RVA: 0x5A22B4 Offset: 0x5A22B4 VA: 0x5A22B4
	private Task<bool> UpdateNetworkReachability(CancellationToken token) { }

	// RVA: 0x5A16E4 Offset: 0x5A16E4 VA: 0x5A16E4
	private void NotifyAvailabilityChanged(bool status) { }

	// RVA: 0x5A1DA8 Offset: 0x5A1DA8 VA: 0x5A1DA8
	private void Destroy() { }

	// RVA: 0x5A2420 Offset: 0x5A2420 VA: 0x5A2420
	public void .ctor() { }
}

// Namespace: SYBO.Subway.App
public class NativeNetworkCheck : AbstractNetworkCheck // TypeDefIndex: 11781
{
	// Fields
	private Log _logger; // 0xC
	private bool _wasEverAvailable; // 0x10
	private NetworkConnectionListener _status; // 0x14

	// Properties
	public override NetworkStatus CurrentNetworkStatus { get; }
	public override int LastInternetCheckTimeMS { get; }
	public override DateTime ServerTime { get; }
	public override bool HasServerTime { get; }
	public override bool IsAvailable { get; }
	public override bool WasEverAvailable { get; }

	// Methods

	// RVA: 0x864320 Offset: 0x864320 VA: 0x864320 Slot: 7
	public override NetworkStatus get_CurrentNetworkStatus() { }

	// RVA: 0x86439C Offset: 0x86439C VA: 0x86439C Slot: 10
	public override int get_LastInternetCheckTimeMS() { }

	// RVA: 0x8643C4 Offset: 0x8643C4 VA: 0x8643C4 Slot: 8
	public override DateTime get_ServerTime() { }

	// RVA: 0x864404 Offset: 0x864404 VA: 0x864404 Slot: 9
	public override bool get_HasServerTime() { }

	// RVA: 0x86442C Offset: 0x86442C VA: 0x86442C Slot: 5
	public override bool get_IsAvailable() { }

	// RVA: 0x8644CC Offset: 0x8644CC VA: 0x8644CC Slot: 6
	public override bool get_WasEverAvailable() { }

	// RVA: 0x8644D4 Offset: 0x8644D4 VA: 0x8644D4 Slot: 4
	public override void Initialize(HttpClient httpClient, Log log) { }

	// RVA: 0x864708 Offset: 0x864708 VA: 0x864708 Slot: 11
	public override Task<bool> ScheduleInternetConnectionCheck() { }

	// RVA: 0x8647A0 Offset: 0x8647A0 VA: 0x8647A0
	private void OnInternalAvailabilityChanged(bool value) { }

	// RVA: 0x8647A8 Offset: 0x8647A8 VA: 0x8647A8
	public void .ctor() { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F5B8 Offset: 0x36F5B8 VA: 0x36F5B8
private struct AppServiceBase.<CallAsync>d__10<TData, TResponse> : IAsyncStateMachine // TypeDefIndex: 11782
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder<TResponse> <>t__builder; // 0x0
	public AppServiceBase <>4__this; // 0x0
	public string url; // 0x0
	public TData data; // 0x0
	public Func<string, TData, Task<TResponse>> request; // 0x0
	private TaskAwaiter<TResponse> <>u__1; // 0x0

	// Methods

	// RVA: -1 Offset: -1 Slot: 4
	private void MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB7D3EC Offset: 0xB7D3EC VA: 0xB7D3EC
	|-AppServiceBase.<CallAsync>d__10<object, object>.MoveNext
	*/

	[DebuggerHiddenAttribute] // RVA: 0x3BD138 Offset: 0x3BD138 VA: 0x3BD138
	// RVA: -1 Offset: -1 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB7D6EC Offset: 0xB7D6EC VA: 0xB7D6EC
	|-AppServiceBase.<CallAsync>d__10<object, object>.SetStateMachine
	*/
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F5C8 Offset: 0x36F5C8 VA: 0x36F5C8
private struct AppServiceBase.<CallAsync>d__11<TData, TResponse> : IAsyncStateMachine // TypeDefIndex: 11783
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder<TResponse> <>t__builder; // 0x0
	public string url; // 0x0
	public AppServiceBase <>4__this; // 0x0
	public string version; // 0x0
	public Func<string, TData, Task<TResponse>> request; // 0x0
	public TData data; // 0x0
	private TaskAwaiter<TResponse> <>u__1; // 0x0
	private TaskAwaiter <>u__2; // 0x0

	// Methods

	// RVA: -1 Offset: -1 Slot: 4
	private void MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB7D72C Offset: 0xB7D72C VA: 0xB7D72C
	|-AppServiceBase.<CallAsync>d__11<object, object>.MoveNext
	*/

	[DebuggerHiddenAttribute] // RVA: 0x3BD148 Offset: 0x3BD148 VA: 0x3BD148
	// RVA: -1 Offset: -1 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB7DEDC Offset: 0xB7DEDC VA: 0xB7DEDC
	|-AppServiceBase.<CallAsync>d__11<object, object>.SetStateMachine
	*/
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F5D8 Offset: 0x36F5D8 VA: 0x36F5D8
private struct AppServiceBase.<Get>d__12<T> : IAsyncStateMachine // TypeDefIndex: 11784
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder<T> <>t__builder; // 0x0
	public string queryString; // 0x0
	public string relativeUrl; // 0x0
	public AppServiceBase <>4__this; // 0x0
	private TaskAwaiter<T> <>u__1; // 0x0

	// Methods

	// RVA: -1 Offset: -1 Slot: 4
	private void MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB83B3C Offset: 0xB83B3C VA: 0xB83B3C
	|-AppServiceBase.<Get>d__12<object>.MoveNext
	*/

	[DebuggerHiddenAttribute] // RVA: 0x3BD158 Offset: 0x3BD158 VA: 0x3BD158
	// RVA: -1 Offset: -1 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB841C0 Offset: 0xB841C0 VA: 0xB841C0
	|-AppServiceBase.<Get>d__12<object>.SetStateMachine
	*/
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F5E8 Offset: 0x36F5E8 VA: 0x36F5E8
private struct AppServiceBase.<GetNoAuth>d__13<T> : IAsyncStateMachine // TypeDefIndex: 11785
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder<T> <>t__builder; // 0x0
	public string queryString; // 0x0
	public string relativeUrl; // 0x0
	public AppServiceBase <>4__this; // 0x0
	public Func<string, T> transform; // 0x0
	private TaskAwaiter<T> <>u__1; // 0x0

	// Methods

	// RVA: -1 Offset: -1 Slot: 4
	private void MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xDBB83C Offset: 0xDBB83C VA: 0xDBB83C
	|-AppServiceBase.<GetNoAuth>d__13<object>.MoveNext
	*/

	[DebuggerHiddenAttribute] // RVA: 0x3BD168 Offset: 0x3BD168 VA: 0x3BD168
	// RVA: -1 Offset: -1 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xDBBED4 Offset: 0xDBBED4 VA: 0xDBBED4
	|-AppServiceBase.<GetNoAuth>d__13<object>.SetStateMachine
	*/
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F5F8 Offset: 0x36F5F8 VA: 0x36F5F8
private struct AppServiceBase.<Post>d__14<T> : IAsyncStateMachine // TypeDefIndex: 11786
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder<T> <>t__builder; // 0x0
	public object data; // 0x0
	public AppServiceBase <>4__this; // 0x0
	public string relativeUrl; // 0x0
	private TaskAwaiter<T> <>u__1; // 0x0

	// Methods

	// RVA: -1 Offset: -1 Slot: 4
	private void MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xDBDFA0 Offset: 0xDBDFA0 VA: 0xDBDFA0
	|-AppServiceBase.<Post>d__14<object>.MoveNext
	*/

	[DebuggerHiddenAttribute] // RVA: 0x3BD178 Offset: 0x3BD178 VA: 0x3BD178
	// RVA: -1 Offset: -1 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xDBE480 Offset: 0xDBE480 VA: 0xDBE480
	|-AppServiceBase.<Post>d__14<object>.SetStateMachine
	*/
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F608 Offset: 0x36F608 VA: 0x36F608
private struct AppServiceBase.<SendRequest>d__15<T> : IAsyncStateMachine // TypeDefIndex: 11787
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder<T> <>t__builder; // 0x0
	public AppServiceBase <>4__this; // 0x0
	public string url; // 0x0
	public HttpMethod method; // 0x0
	public HttpContent content; // 0x0
	public bool addAuthToken; // 0x0
	public Func<string, T> transform; // 0x0
	private YieldAwaitable.YieldAwaiter <>u__1; // 0x0
	private TaskAwaiter<T> <>u__2; // 0x0

	// Methods

	// RVA: -1 Offset: -1 Slot: 4
	private void MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xDC371C Offset: 0xDC371C VA: 0xDC371C
	|-AppServiceBase.<SendRequest>d__15<object>.MoveNext
	*/

	[DebuggerHiddenAttribute] // RVA: 0x3BD188 Offset: 0x3BD188 VA: 0x3BD188
	// RVA: -1 Offset: -1 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xDC3B38 Offset: 0xDC3B38 VA: 0xDC3B38
	|-AppServiceBase.<SendRequest>d__15<object>.SetStateMachine
	*/
}

// Namespace: SYBO.Subway.App
public class AppServiceBase // TypeDefIndex: 11788
{
	// Fields
	private HttpClient _httpClient; // 0x8
	private string _endpoint; // 0xC
	private Log _logger; // 0x10
	private RequestResolver _resolver; // 0x14
	private string _id; // 0x18

	// Properties
	protected virtual string ServiceVersion { get; }

	// Methods

	// RVA: 0x692D58 Offset: 0x692D58 VA: 0x692D58 Slot: 4
	protected virtual string get_ServiceVersion() { }

	// RVA: 0x692DA4 Offset: 0x692DA4 VA: 0x692DA4
	protected void .ctor(string id) { }

	// RVA: 0x692F64 Offset: 0x692F64 VA: 0x692F64
	public void Setup(string endpoint) { }

	// RVA: 0x692F6C Offset: 0x692F6C VA: 0x692F6C
	public void Setup(Log logger, HttpClient httpClient) { }

	[AsyncStateMachineAttribute] // RVA: 0x3BCEB0 Offset: 0x3BCEB0 VA: 0x3BCEB0
	// RVA: -1 Offset: -1
	protected Task<TResponse> CallAsync<TData, TResponse>(string url, TData data, Func<string, TData, Task<TResponse>> request) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xACFB38 Offset: 0xACFB38 VA: 0xACFB38
	|-AppServiceBase.CallAsync<CreateChallengeGroupRequest, ChallengeResponse>
	|-AppServiceBase.CallAsync<DeleteDataRequest, DataProcessingResponse>
	|-AppServiceBase.CallAsync<GetFriendMetricsRequest, GetFriendMetricsResponse>
	|-AppServiceBase.CallAsync<IAPValidateRequest, IAPValidateResponse>
	|-AppServiceBase.CallAsync<MailRequest, BaseResponse>
	|-AppServiceBase.CallAsync<MailRequest, MailClaimResponse>
	|-AppServiceBase.CallAsync<object, object>
	|-AppServiceBase.CallAsync<PostMetricsRequest, BaseResponse>
	|-AppServiceBase.CallAsync<PromoCodeRedeemRequest, PromoCodeRedeemResponse>
	|-AppServiceBase.CallAsync<StoreProfileRequest, RestResponse>
	|-AppServiceBase.CallAsync<string, DataProcessingResponse>
	|-AppServiceBase.CallAsync<string, GetProfileResponse>
	|-AppServiceBase.CallAsync<string, MailResponse>
	|-AppServiceBase.CallAsync<SubmitChallengeScoresRequest, BaseResponse>
	*/

	[AsyncStateMachineAttribute] // RVA: 0x3BCF1C Offset: 0x3BCF1C VA: 0x3BCF1C
	// RVA: -1 Offset: -1
	protected Task<TResponse> CallAsync<TData, TResponse>(string url, string version, TData data, Func<string, TData, Task<TResponse>> request) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xACFC74 Offset: 0xACFC74 VA: 0xACFC74
	|-AppServiceBase.CallAsync<object, object>
	|-AppServiceBase.CallAsync<string, ChallengeResponse>
	|-AppServiceBase.CallAsync<string, GetFriendsResponse>
	|-AppServiceBase.CallAsync<string, TournamentResponse>
	|-AppServiceBase.CallAsync<TournamentRequest, TournamentResponse>
	*/

	[AsyncStateMachineAttribute] // RVA: 0x3BCF88 Offset: 0x3BCF88 VA: 0x3BCF88
	// RVA: -1 Offset: -1
	protected Task<T> Get<T>(string relativeUrl, string queryString) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xACFDBC Offset: 0xACFDBC VA: 0xACFDBC
	|-AppServiceBase.Get<ChallengeResponse>
	|-AppServiceBase.Get<DataProcessingResponse>
	|-AppServiceBase.Get<GetFriendsResponse>
	|-AppServiceBase.Get<GetProfileResponse>
	|-AppServiceBase.Get<MailResponse>
	|-AppServiceBase.Get<object>
	|-AppServiceBase.Get<TournamentResponse>
	*/

	[AsyncStateMachineAttribute] // RVA: 0x3BCFF4 Offset: 0x3BCFF4 VA: 0x3BCFF4
	// RVA: -1 Offset: -1
	protected Task<T> GetNoAuth<T>(string relativeUrl, string queryString, Func<string, T> transform) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xACFEFC Offset: 0xACFEFC VA: 0xACFEFC
	|-AppServiceBase.GetNoAuth<GamedataReferenceResponse>
	|-AppServiceBase.GetNoAuth<object>
	*/

	[AsyncStateMachineAttribute] // RVA: 0x3BD060 Offset: 0x3BD060 VA: 0x3BD060
	// RVA: -1 Offset: -1
	protected Task<T> Post<T>(string relativeUrl, object data) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xAD003C Offset: 0xAD003C VA: 0xAD003C
	|-AppServiceBase.Post<BaseResponse>
	|-AppServiceBase.Post<ChallengeResponse>
	|-AppServiceBase.Post<DataProcessingResponse>
	|-AppServiceBase.Post<GetFriendMetricsResponse>
	|-AppServiceBase.Post<IAPValidateResponse>
	|-AppServiceBase.Post<MailClaimResponse>
	|-AppServiceBase.Post<object>
	|-AppServiceBase.Post<PromoCodeRedeemResponse>
	|-AppServiceBase.Post<RestResponse>
	|-AppServiceBase.Post<TournamentResponse>
	*/

	[AsyncStateMachineAttribute] // RVA: 0x3BD0CC Offset: 0x3BD0CC VA: 0x3BD0CC
	// RVA: -1 Offset: -1
	private Task<T> SendRequest<T>(string url, HttpMethod method, HttpContent content, bool addAuthToken = True, Func<string, T> transform) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xAD017C Offset: 0xAD017C VA: 0xAD017C
	|-AppServiceBase.SendRequest<object>
	*/

	// RVA: 0x692FF4 Offset: 0x692FF4 VA: 0x692FF4
	private string PrintHeaders() { }

	// RVA: 0x6933A4 Offset: 0x6933A4 VA: 0x6933A4 Slot: 3
	public override string ToString() { }
}

// Namespace: SYBO.Subway.App
public class RestResponse // TypeDefIndex: 11789
{
	// Fields
	public bool IsSuccess; // 0x8
	public HttpStatusCode StatusCode; // 0xC
	public HttpHeaders Headers; // 0x10
	public string RawResponse; // 0x14
	public long Duration; // 0x18

	// Methods

	// RVA: 0x9162A4 Offset: 0x9162A4 VA: 0x9162A4
	public string TryGetHeader(string header, string fallback = "") { }

	// RVA: 0x916348 Offset: 0x916348 VA: 0x916348
	public void .ctor() { }
}

// Namespace: SYBO.Subway.App
public class BaseResponse : RestResponse // TypeDefIndex: 11790
{
	// Fields
	public DateTime ts; // 0x20
	public string error; // 0x28
	public int kind; // 0x2C

	// Methods

	// RVA: 0x6A9388 Offset: 0x6A9388 VA: 0x6A9388
	public void .ctor() { }
}

// Namespace: SYBO.Subway.App
public class AppServices // TypeDefIndex: 11791
{
	// Fields
	private static AppServices _instance; // 0x0
	private List<AppServiceBase> _services; // 0x8
	private Log _logger; // 0xC
	private HttpClient _httpClient; // 0x10
	private string _endpoint; // 0x14

	// Properties
	public static AppServices Instance { get; }
	public List<AppServiceBase> Services { get; }

	// Methods

	// RVA: 0x692DE4 Offset: 0x692DE4 VA: 0x692DE4
	public static AppServices get_Instance() { }

	// RVA: 0x6934F8 Offset: 0x6934F8 VA: 0x6934F8
	public List<AppServiceBase> get_Services() { }

	// RVA: 0x6933C4 Offset: 0x6933C4 VA: 0x6933C4
	public void .ctor() { }

	// RVA: 0x692E5C Offset: 0x692E5C VA: 0x692E5C
	public void Register(AppServiceBase service) { }

	// RVA: 0x693500 Offset: 0x693500 VA: 0x693500
	public void Initialize(HttpClient httpClient) { }

	// RVA: 0x69366C Offset: 0x69366C VA: 0x69366C
	public void SetupEndpoint(string endpoint) { }
}

// Namespace: SYBO.Subway.App
[SettingsPresentationAttribute] // RVA: 0x36F618 Offset: 0x36F618 VA: 0x36F618
[SettingsAttribute] // RVA: 0x36F618 Offset: 0x36F618 VA: 0x36F618
public class AppServicesSettings // TypeDefIndex: 11792
{
	// Fields
	[AppServiceSettingIdAttribute] // RVA: 0x3AB3C8 Offset: 0x3AB3C8 VA: 0x3AB3C8
	public AppServiceSettings MailBox; // 0x8
	[AppServiceSettingIdAttribute] // RVA: 0x3AB3FC Offset: 0x3AB3FC VA: 0x3AB3FC
	public AppServiceSettings IAP; // 0xC
	[AppServiceSettingIdAttribute] // RVA: 0x3AB430 Offset: 0x3AB430 VA: 0x3AB430
	public AppServiceSettings Profile; // 0x10
	[AppServiceSettingIdAttribute] // RVA: 0x3AB464 Offset: 0x3AB464 VA: 0x3AB464
	public AppServiceSettings PromoCodes; // 0x14
	[AppServiceSettingIdAttribute] // RVA: 0x3AB498 Offset: 0x3AB498 VA: 0x3AB498
	public AppServiceSettings TopRun; // 0x18
	[AppServiceSettingIdAttribute] // RVA: 0x3AB4CC Offset: 0x3AB4CC VA: 0x3AB4CC
	public AppServiceSettings Friends; // 0x1C
	[AppServiceSettingIdAttribute] // RVA: 0x3AB500 Offset: 0x3AB500 VA: 0x3AB500
	public AppServiceSettings Challenges; // 0x20
	[AppServiceSettingIdAttribute] // RVA: 0x3AB534 Offset: 0x3AB534 VA: 0x3AB534
	public AppServiceSettings DataProtection; // 0x24
	private Dictionary<string, AppServiceSettings> _cache; // 0x28

	// Methods

	// RVA: 0x6937C4 Offset: 0x6937C4 VA: 0x6937C4
	public void .ctor() { }

	// RVA: 0x693900 Offset: 0x693900 VA: 0x693900
	public AppServiceSettings Get(string key) { }
}

// Namespace: SYBO.Subway.App
public class AppServiceSettingIdAttribute : Attribute // TypeDefIndex: 11793
{
	// Fields
	public string Id; // 0x8

	// Methods

	// RVA: 0x6933AC Offset: 0x6933AC VA: 0x6933AC
	public void .ctor() { }
}

// Namespace: SYBO.Subway.App
public class AppServiceSettings // TypeDefIndex: 11794
{
	// Fields
	public AppServiceMockStrategy Mock; // 0x8
	public bool EnforceStatusCode; // 0xC
	public int DelayInMS; // 0x10
	public HttpStatusCode DefaultStatusCode; // 0x14

	// Methods

	// RVA: 0x6933B4 Offset: 0x6933B4 VA: 0x6933B4
	public void .ctor() { }
}

// Namespace: SYBO.Subway.App
public enum AppServiceMockStrategy // TypeDefIndex: 11795
{
	// Fields
	public int value__; // 0x0
	public const AppServiceMockStrategy None = 0;
	public const AppServiceMockStrategy HttpClient = 1;
	public const AppServiceMockStrategy Resolver = 2;
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F67C Offset: 0x36F67C VA: 0x36F67C
private struct MockHttpClientEditor.<SendAsync>d__2 : IAsyncStateMachine // TypeDefIndex: 11796
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder<HttpResponseMessage> <>t__builder; // 0x4
	public MockHttpClientEditor <>4__this; // 0x10
	public HttpRequestMessage request; // 0x14
	public CancellationToken cancellationToken; // 0x18
	private HttpResponseMessage <response>5__2; // 0x1C
	private AppServiceSettings <settings>5__3; // 0x20
	private TaskAwaiter<Stream> <>u__1; // 0x24
	private TaskAwaiter <>u__2; // 0x28
	private YieldAwaitable.YieldAwaiter <>u__3; // 0x2C

	// Methods

	// RVA: 0x783498 Offset: 0x783498 VA: 0x783498 Slot: 4
	private void MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BD204 Offset: 0x3BD204 VA: 0x3BD204
	// RVA: 0x7842DC Offset: 0x7842DC VA: 0x7842DC Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
}

// Namespace: SYBO.Subway.App
public class MockHttpClientEditor : HttpClient // TypeDefIndex: 11797
{
	// Fields
	private string _serviceName; // 0x30

	// Methods

	// RVA: 0x9FCF74 Offset: 0x9FCF74 VA: 0x9FCF74
	public void .ctor(string serviceName) { }

	[AsyncStateMachineAttribute] // RVA: 0x3BD198 Offset: 0x3BD198 VA: 0x3BD198
	// RVA: 0x9FCFF4 Offset: 0x9FCFF4 VA: 0x9FCFF4 Slot: 6
	public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F68C Offset: 0x36F68C VA: 0x36F68C
private struct MockHttpClientStreamingAssets.<SendAsync>d__2 : IAsyncStateMachine // TypeDefIndex: 11798
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder<HttpResponseMessage> <>t__builder; // 0x4
	public MockHttpClientStreamingAssets <>4__this; // 0x10
	public HttpRequestMessage request; // 0x14
	public CancellationToken cancellationToken; // 0x18
	private HttpResponseMessage <response>5__2; // 0x1C
	private TaskAwaiter <>u__1; // 0x20
	private YieldAwaitable.YieldAwaiter <>u__2; // 0x24

	// Methods

	// RVA: 0x8D15A0 Offset: 0x8D15A0 VA: 0x8D15A0 Slot: 4
	private void MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BD280 Offset: 0x3BD280 VA: 0x3BD280
	// RVA: 0x8D1E70 Offset: 0x8D1E70 VA: 0x8D1E70 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
}

// Namespace: SYBO.Subway.App
public class MockHttpClientStreamingAssets : HttpClient // TypeDefIndex: 11799
{
	// Fields
	private string _serviceName; // 0x30

	// Methods

	// RVA: 0x9FD168 Offset: 0x9FD168 VA: 0x9FD168
	public void .ctor(string serviceName) { }

	[AsyncStateMachineAttribute] // RVA: 0x3BD214 Offset: 0x3BD214 VA: 0x3BD214
	// RVA: 0x9FD1E8 Offset: 0x9FD1E8 VA: 0x9FD1E8 Slot: 6
	public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F69C Offset: 0x36F69C VA: 0x36F69C
private struct MockRequestResolver.<SendRequest>d__5<T> : IAsyncStateMachine // TypeDefIndex: 11800
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder<T> <>t__builder; // 0x0
	public string url; // 0x0
	public MockRequestResolver <>4__this; // 0x0
	public HttpMethod method; // 0x0
	private T <responseData>5__2; // 0x0
	private TaskAwaiter <>u__1; // 0x0
	private YieldAwaitable.YieldAwaiter <>u__2; // 0x0

	// Methods

	// RVA: -1 Offset: -1 Slot: 4
	private void MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xDC4AC0 Offset: 0xDC4AC0 VA: 0xDC4AC0
	|-MockRequestResolver.<SendRequest>d__5<object>.MoveNext
	*/

	[DebuggerHiddenAttribute] // RVA: 0x3BD2FC Offset: 0x3BD2FC VA: 0x3BD2FC
	// RVA: -1 Offset: -1 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xDC5108 Offset: 0xDC5108 VA: 0xDC5108
	|-MockRequestResolver.<SendRequest>d__5<object>.SetStateMachine
	*/
}

// Namespace: SYBO.Subway.App
public class MockRequestResolver : RequestResolver // TypeDefIndex: 11801
{
	// Fields
	private string _id; // 0x10
	private Dictionary<HttpMethod, Dictionary<string, Func<RestResponse>>> _resolvers; // 0x14

	// Methods

	// RVA: 0x9FD704 Offset: 0x9FD704 VA: 0x9FD704
	public void .ctor(string id, Log logger, HttpClient httpClient) { }

	// RVA: 0x9FD7AC Offset: 0x9FD7AC VA: 0x9FD7AC
	protected void RegisterResolver(HttpMethod method, string url, Func<RestResponse> resolver) { }

	// RVA: 0x9FD9B0 Offset: 0x9FD9B0 VA: 0x9FD9B0
	protected Func<RestResponse> Get(HttpMethod method, string url) { }

	[AsyncStateMachineAttribute] // RVA: 0x3BD290 Offset: 0x3BD290 VA: 0x3BD290
	// RVA: -1 Offset: -1 Slot: 4
	public override Task<T> SendRequest<T>(string url, HttpMethod method, HttpContent content, bool addAuthToken = True, Func<string, T> transform) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xF49974 Offset: 0xF49974 VA: 0xF49974
	|-MockRequestResolver.SendRequest<object>
	*/
}

// Namespace: SYBO.Subway.App
public abstract class RequestResolver // TypeDefIndex: 11802
{
	// Fields
	protected Log _logger; // 0x8
	protected HttpClient _httpClient; // 0xC

	// Methods

	// RVA: 0x90F390 Offset: 0x90F390 VA: 0x90F390
	protected void .ctor(Log logger, HttpClient httpClient) { }

	// RVA: -1 Offset: -1 Slot: 4
	public abstract Task<T> SendRequest<T>(string url, HttpMethod method, HttpContent content, bool addAuthToken = True, Func<string, T> transform);
	/* GenericInstMethod :
	|
	|-RVA: -1 Offset: -1
	|-RequestResolver.SendRequest<object>
	*/
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F6AC Offset: 0x36F6AC VA: 0x36F6AC
private struct DefaultRequestResolver.<SendRequest>d__1<T> : IAsyncStateMachine // TypeDefIndex: 11803
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder<T> <>t__builder; // 0x0
	public HttpMethod method; // 0x0
	public string url; // 0x0
	public HttpContent content; // 0x0
	public bool addAuthToken; // 0x0
	public DefaultRequestResolver <>4__this; // 0x0
	public Func<string, T> transform; // 0x0
	private HttpRequestMessage <messageRequest>5__2; // 0x0
	private Stopwatch <stopWatch>5__3; // 0x0
	private HttpResponseMessage <responseMessage>5__4; // 0x0
	private HttpStatusCode <statusCode>5__5; // 0x0
	private TaskAwaiter<AuthIdentityToken> <>u__1; // 0x0
	private TaskAwaiter<HttpResponseMessage> <>u__2; // 0x0
	private TaskAwaiter<string> <>u__3; // 0x0

	// Methods

	// RVA: -1 Offset: -1 Slot: 4
	private void MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xDC3B78 Offset: 0xDC3B78 VA: 0xDC3B78
	|-DefaultRequestResolver.<SendRequest>d__1<object>.MoveNext
	*/

	[DebuggerHiddenAttribute] // RVA: 0x3BD378 Offset: 0x3BD378 VA: 0x3BD378
	// RVA: -1 Offset: -1 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xDC4A80 Offset: 0xDC4A80 VA: 0xDC4A80
	|-DefaultRequestResolver.<SendRequest>d__1<object>.SetStateMachine
	*/
}

// Namespace: SYBO.Subway.App
public class DefaultRequestResolver : RequestResolver // TypeDefIndex: 11804
{
	// Methods

	// RVA: 0x60AA58 Offset: 0x60AA58 VA: 0x60AA58
	public void .ctor(Log logger, HttpClient httpClient) { }

	[AsyncStateMachineAttribute] // RVA: 0x3BD30C Offset: 0x3BD30C VA: 0x3BD30C
	// RVA: -1 Offset: -1 Slot: 4
	public override Task<T> SendRequest<T>(string url, HttpMethod method, HttpContent content, bool addAuthToken = True, Func<string, T> transform) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x673128 Offset: 0x673128 VA: 0x673128
	|-DefaultRequestResolver.SendRequest<object>
	*/
}

// Namespace: SYBO.Subway.Analytics
public class AnalyticsEventController // TypeDefIndex: 11805
{
	// Fields
	private const string DefaultId = "default";
	public static AnalyticsEventController Instance; // 0x0
	private GameStartedEvent _gameStartedAnalyticsEvent; // 0x8
	private RunFinishedEvent _runFinishedAnalyticsEvent; // 0xC
	private ReviveOfferedEvent _reviveOfferedAnalyticsEvent; // 0x10
	private PromoCodeRedeemedEvent _promoCodeRedeemedAnalyticsEvent; // 0x14
	private CurrencySpentEvent _currencySpentAnalyticsEvent; // 0x18
	private PermanentlyUnlockedEvent _permanentlyUnlockedEvent; // 0x1C
	private CurrencyReceivedEvent _currencyReceivedAnalyticsEvent; // 0x20
	private BoxOpenedEvent _boxOpenendAnalyticsEvent; // 0x24
	private SocialProviderLinkEvent _socialProviderLinkAnalyticsEvent; // 0x28
	private GlobalBool _isInPlaystate; // 0x2C
	private AnalyticsHelper _analyticsHelper; // 0x30

	// Methods

	// RVA: 0x6F76DC Offset: 0x6F76DC VA: 0x6F76DC
	public void Initialize() { }

	// RVA: 0x6F9168 Offset: 0x6F9168 VA: 0x6F9168
	private void HandleRunEventHit() { }

	// RVA: 0x6F9268 Offset: 0x6F9268 VA: 0x6F9268
	private void HandleRunEventStumbleTwice() { }

	// RVA: 0x6F9270 Offset: 0x6F9270 VA: 0x6F9270
	private void OnPowerupState(PowerupStateData state) { }

	// RVA: 0x6F933C Offset: 0x6F933C VA: 0x6F933C
	private void HandlePlayerQuitRun() { }

	// RVA: 0x6F9344 Offset: 0x6F9344 VA: 0x6F9344
	private void HandlePlayerRanOutOfTime() { }

	// RVA: 0x6F934C Offset: 0x6F934C VA: 0x6F934C
	private void HandleApplicationQuit() { }

	// RVA: 0x6F9354 Offset: 0x6F9354 VA: 0x6F9354
	public void Destroy() { }

	// RVA: 0x6FAB8C Offset: 0x6FAB8C VA: 0x6FAB8C
	private void HandleGameStarted() { }

	// RVA: 0x6F9170 Offset: 0x6F9170 VA: 0x6F9170
	private void HandleRunFinished(RunEndedReason reason) { }

	// RVA: 0x6FAFA0 Offset: 0x6FAFA0 VA: 0x6FAFA0
	private void NotifyOfReviveChoice(ReviveChoiceEventInfo data) { }

	// RVA: 0x6FB488 Offset: 0x6FB488 VA: 0x6FB488
	private void NotifyRevivePurchasedWithKeys(int cost) { }

	// RVA: 0x6FB634 Offset: 0x6FB634 VA: 0x6FB634
	private int GetCurrencyBalance(CurrencyType currency) { }

	// RVA: 0x6FB6B4 Offset: 0x6FB6B4 VA: 0x6FB6B4
	private void HandleSocialProviderAccountLinked(AuthProvider id) { }

	// RVA: 0x6FB75C Offset: 0x6FB75C VA: 0x6FB75C
	private void HandleSocialProviderAccountUnlinked(AuthProvider id) { }

	// RVA: 0x6FB804 Offset: 0x6FB804 VA: 0x6FB804
	private void HandleSocialProviderLinkError(AuthProvider id) { }

	// RVA: 0x6FB8AC Offset: 0x6FB8AC VA: 0x6FB8AC
	private void HandleCurrencySpent(ProductData productData) { }

	// RVA: 0x6FBA0C Offset: 0x6FBA0C VA: 0x6FBA0C
	private void HandleBoardPermanentlyUnlocked(BoardUpgradeIdentifier identifier, RewardOrigin origin) { }

	// RVA: 0x6FBB24 Offset: 0x6FBB24 VA: 0x6FBB24
	private void HandleCharacterPermanentlyUnlocked(CharacterOutfitIdentifier identifier, RewardOrigin origin) { }

	// RVA: 0x6FBC3C Offset: 0x6FBC3C VA: 0x6FBC3C
	private void HandleUpgradePermanentlyUnlocked(string itemId, int level, RewardOrigin origin) { }

	// RVA: 0x6FBCBC Offset: 0x6FBCBC VA: 0x6FBCBC
	private void HandleBoxOpened(BoxOpenedEventData e) { }

	// RVA: 0x6FBD4C Offset: 0x6FBD4C VA: 0x6FBD4C
	private void HandleCurrencyReceived(Currency currency, int amount, RewardOrigin origin) { }

	// RVA: 0x6FBD90 Offset: 0x6FBD90 VA: 0x6FBD90
	private void TrackCurrencyReceived(CurrencyType type, int amount, RewardOrigin origin) { }

	// RVA: 0x6FBE88 Offset: 0x6FBE88 VA: 0x6FBE88
	private void HandleProfileLoaded(ProfileModel model) { }

	// RVA: 0x6FBFF0 Offset: 0x6FBFF0 VA: 0x6FBFF0
	private void HandleMissionPurchased(MissionEntry mission) { }

	// RVA: 0x6FC4EC Offset: 0x6FC4EC VA: 0x6FC4EC
	private void HandleSeasonHuntRewardClaimed(SeasonHuntTier tier) { }

	// RVA: 0x6FC5A0 Offset: 0x6FC5A0 VA: 0x6FC5A0
	private void HandleSeasonHuntRewardUnlocked(SeasonHuntTier tier) { }

	// RVA: 0x6FC664 Offset: 0x6FC664 VA: 0x6FC664
	private void HandleSeasonHuntTierSkipped(SeasonHuntTier skippedTier, Currency skipCost) { }

	// RVA: 0x6FC9E8 Offset: 0x6FC9E8 VA: 0x6FC9E8
	private void HandleCooldownSkipped(string itemId, Currency skipCost) { }

	// RVA: 0x6FCBB4 Offset: 0x6FCBB4 VA: 0x6FCBB4
	private void HandleCodeRedeemed(string code) { }

	// RVA: 0x6FCC1C Offset: 0x6FCC1C VA: 0x6FCC1C
	private void HandleEliteChallengeRewardUnlocked(ChallengeInstanceData challengeInstance) { }

	// RVA: 0x6FCD00 Offset: 0x6FCD00 VA: 0x6FCD00
	private void HandleEliteChallengeRewardClaimed(ChallengeInstanceData challengeInstance, RewardTierData tier, int tierIndex) { }

	// RVA: 0x6FCD94 Offset: 0x6FCD94 VA: 0x6FCD94
	private void HandleChallengeStartedFirstTime(ChallengeInstanceData challengeInstance) { }

	// RVA: 0x6FCDE4 Offset: 0x6FCDE4 VA: 0x6FCDE4
	private void HandleChallengeRewardUnlocked(ChallengeInstanceData challengeInstance, RewardTierData tier, int tierIndex) { }

	// RVA: 0x6FCE78 Offset: 0x6FCE78 VA: 0x6FCE78
	private void HandleChallengeRewardClaimed(ChallengeInstanceData challengeInstance, RewardTierData tier, int tierIndex) { }

	// RVA: 0x6FCF0C Offset: 0x6FCF0C VA: 0x6FCF0C
	private void HandleMissionUnlocked(MissionEntry mission) { }

	// RVA: 0x6FD094 Offset: 0x6FD094 VA: 0x6FD094
	private void HandleMissionClaimed(MissionEntry mission, SharedFeaturePlacementType placementType = 1) { }

	// RVA: 0x6FD224 Offset: 0x6FD224 VA: 0x6FD224
	public void .ctor() { }

	// RVA: 0x6FD434 Offset: 0x6FD434 VA: 0x6FD434
	private static void .cctor() { }
}

// Namespace: SYBO.Subway.Analytics
public enum ReviveHintType // TypeDefIndex: 11806
{
	// Fields
	public int value__; // 0x0
	public const ReviveHintType None = 0;
	public const ReviveHintType HighScore = 1;
	public const ReviveHintType DailyChallenge = 2;
	public const ReviveHintType CoinMeter = 3;
	public const ReviveHintType CityChallege = 4;
}

// Namespace: SYBO.Subway.Analytics
public class AnalyticsHelper // TypeDefIndex: 11807
{
	// Fields
	public RunStats Stats; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x3AB568 Offset: 0x3AB568 VA: 0x3AB568
	private bool <HasSentRunFinishedEvent>k__BackingField; // 0xC
	public static readonly AnalyticsHelper Instance; // 0x0

	// Properties
	public bool HasSentRunFinishedEvent { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x3BD388 Offset: 0x3BD388 VA: 0x3BD388
	// RVA: 0x6FD498 Offset: 0x6FD498 VA: 0x6FD498
	public bool get_HasSentRunFinishedEvent() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BD398 Offset: 0x3BD398 VA: 0x3BD398
	// RVA: 0x6FD4A0 Offset: 0x6FD4A0 VA: 0x6FD4A0
	public void set_HasSentRunFinishedEvent(bool value) { }

	// RVA: 0x6FD4A8 Offset: 0x6FD4A8 VA: 0x6FD4A8
	private void .ctor() { }

	// RVA: 0x6FACC0 Offset: 0x6FACC0 VA: 0x6FACC0
	public void StartNewGame() { }

	// RVA: 0x6F92B4 Offset: 0x6F92B4 VA: 0x6F92B4
	public void HandleHoverboardUsed() { }

	// RVA: 0x6FD594 Offset: 0x6FD594 VA: 0x6FD594
	public void HandleHoverboardHit() { }

	// RVA: 0x6FD61C Offset: 0x6FD61C VA: 0x6FD61C
	public void HandleHeadstartUsed() { }

	// RVA: 0x6FD6A4 Offset: 0x6FD6A4 VA: 0x6FD6A4
	public void HandleScoreBoosterUsed() { }

	// RVA: 0x6FD72C Offset: 0x6FD72C VA: 0x6FD72C
	public void HandleTokenCollected(int amount) { }

	// RVA: 0x6FD7B8 Offset: 0x6FD7B8 VA: 0x6FD7B8
	public void HandleKeyCollected(int amount) { }

	// RVA: 0x6FD844 Offset: 0x6FD844 VA: 0x6FD844
	public void HandleCoinsCollected(int coins) { }

	// RVA: 0x6FD8D0 Offset: 0x6FD8D0 VA: 0x6FD8D0
	public void HandleBoxCollected() { }

	// RVA: 0x6FD958 Offset: 0x6FD958 VA: 0x6FD958
	public void HandleLetterCollected() { }

	// RVA: 0x6FD9E0 Offset: 0x6FD9E0 VA: 0x6FD9E0
	public void HandleTimeBoosterCollected() { }

	// RVA: 0x6FDA68 Offset: 0x6FDA68 VA: 0x6FDA68
	public void HandleStumble() { }

	// RVA: 0x6FDAF0 Offset: 0x6FDAF0 VA: 0x6FDAF0
	public void HandlePointsChanged() { }

	// RVA: 0x6FB3E8 Offset: 0x6FB3E8 VA: 0x6FB3E8
	public void HandleRevive(ReviveChoiceType type) { }

	// RVA: 0x6FACC4 Offset: 0x6FACC4 VA: 0x6FACC4
	public void UpdateRunEndStats() { }

	// RVA: 0x6FD518 Offset: 0x6FD518 VA: 0x6FD518
	private void Reset() { }

	// RVA: 0x6FDC0C Offset: 0x6FDC0C VA: 0x6FDC0C
	private static void .cctor() { }
}

// Namespace: SYBO.Subway.Analytics
public class RunStats // TypeDefIndex: 11808
{
	// Fields
	public int RunNumber; // 0x8
	public int TotalKeyRevives; // 0xC
	public int TotalAdRevives; // 0x10
	public string ChallengeSetsActive; // 0x14
	public RunStatsGroup CurrentRunStats; // 0x18
	public RunStatsGroup TotalRunStats; // 0x1C

	// Methods

	// RVA: 0x94A220 Offset: 0x94A220 VA: 0x94A220
	public void StartNewRun() { }

	// RVA: 0x94A298 Offset: 0x94A298 VA: 0x94A298
	public void Reset() { }

	// RVA: 0x94A328 Offset: 0x94A328 VA: 0x94A328
	public void .ctor() { }
}

// Namespace: SYBO.Subway.Analytics
public class RunStatsGroup // TypeDefIndex: 11809
{
	// Fields
	public int HoverboardsUsed; // 0x8
	public int HoverboardHits; // 0xC
	public int HeadstartsUsed; // 0x10
	public int ScoreBoostersUsed; // 0x14
	public int TokensCollected; // 0x18
	public int KeysCollected; // 0x1C
	public int CoinsCollected; // 0x20
	public int BoxesCollected; // 0x24
	public long Points; // 0x28
	public float RunTime; // 0x30
	public int StumbleCount; // 0x34
	public int LettersCollected; // 0x38
	public int RunSpeed; // 0x3C
	public float AvgFps; // 0x40
	public int TimeBoostersCollected; // 0x44

	// Methods

	// RVA: 0x94A290 Offset: 0x94A290 VA: 0x94A290
	public void .ctor() { }
}

// Namespace: SYBO.Subway.Analytics
public enum AnalyticsProductType // TypeDefIndex: 11810
{
	// Fields
	public int value__; // 0x0
	public const AnalyticsProductType None = 0;
	public const AnalyticsProductType Consumable = 1;
	public const AnalyticsProductType LootBox = 2;
	public const AnalyticsProductType Character = 3;
	public const AnalyticsProductType Outfit = 4;
	public const AnalyticsProductType Board = 5;
	public const AnalyticsProductType BoardAbility = 6;
	public const AnalyticsProductType City = 7;
	public const AnalyticsProductType Upgrade = 8;
	public const AnalyticsProductType Bundle = 9;
}

// Namespace: SYBO.Subway.Analytics
public enum AnalyticsProgressActionType // TypeDefIndex: 11811
{
	// Fields
	public int value__; // 0x0
	public const AnalyticsProgressActionType Default = 0;
	public const AnalyticsProgressActionType MissionSkip = 1;
	public const AnalyticsProgressActionType Run = 2;
	public const AnalyticsProgressActionType SeasonHuntSkip = 3;
	public const AnalyticsProgressActionType CooldownSkip = 4;
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F6BC Offset: 0x36F6BC VA: 0x36F6BC
private sealed class AnalyticsNavigationController.<>c__DisplayClass16_0 // TypeDefIndex: 11812
{
	// Fields
	public string viewConfigId; // 0x8

	// Methods

	// RVA: 0x890204 Offset: 0x890204 VA: 0x890204
	public void .ctor() { }

	// RVA: 0x89020C Offset: 0x89020C VA: 0x89020C
	internal bool <HandleNavigatedToView>b__0(TabNavigation o) { }
}

// Namespace: SYBO.Subway.Analytics
public class AnalyticsNavigationController : MonoBehaviour // TypeDefIndex: 11813
{
	// Fields
	[SerializeField] // RVA: 0x3AB578 Offset: 0x3AB578 VA: 0x3AB578
	[TooltipAttribute] // RVA: 0x3AB578 Offset: 0x3AB578 VA: 0x3AB578
	private List<ViewConfigId> _trackedViewsId; // 0xC
	private List<string> _trackedViewsIdValues; // 0x10
	[SerializeField] // RVA: 0x3AB5C0 Offset: 0x3AB5C0 VA: 0x3AB5C0
	[TooltipAttribute] // RVA: 0x3AB5C0 Offset: 0x3AB5C0 VA: 0x3AB5C0
	private List<TabNavigation> _trackedTabNavigations; // 0x14
	private ScreenShownEvent _screenShownEvent; // 0x18
	[SerializeField] // RVA: 0x3AB608 Offset: 0x3AB608 VA: 0x3AB608
	private bool _debug; // 0x1C
	private string _previousViewId; // 0x20
	private string _currentViewId; // 0x24
	private string _previousTabName; // 0x28
	private string _currentTabName; // 0x2C
	private bool _timerActive; // 0x30
	private float _timeInCurrentView; // 0x34

	// Properties
	private bool ShouldReportEvent { get; }

	// Methods

	// RVA: 0x6FE4DC Offset: 0x6FE4DC VA: 0x6FE4DC
	private bool get_ShouldReportEvent() { }

	// RVA: 0x6FE5D8 Offset: 0x6FE5D8 VA: 0x6FE5D8
	private void Awake() { }

	// RVA: 0x6FE96C Offset: 0x6FE96C VA: 0x6FE96C
	private void OnDestroy() { }

	// RVA: 0x6FEC0C Offset: 0x6FEC0C VA: 0x6FEC0C
	private void Update() { }

	// RVA: 0x6FEC7C Offset: 0x6FEC7C VA: 0x6FEC7C
	private void HandleNavigatedToView(NavigationContext context) { }

	// RVA: 0x6FF168 Offset: 0x6FF168 VA: 0x6FF168
	private void HandleNavigationToTab(TabNavigation tabNavigation) { }

	// RVA: 0x6FF304 Offset: 0x6FF304 VA: 0x6FF304
	private bool IsTabNavigationTracked(TabNavigation tabNavigation) { }

	// RVA: 0x6FEECC Offset: 0x6FEECC VA: 0x6FEECC
	private void TrackView(NavigationContext context, string tabName) { }

	// RVA: 0x6FF498 Offset: 0x6FF498 VA: 0x6FF498
	private string GetViewName(string viewConfigId, string tabName) { }

	// RVA: 0x6FF5AC Offset: 0x6FF5AC VA: 0x6FF5AC
	private string GetNextViewData(NavigationContext context) { }

	// RVA: 0x6FF644 Offset: 0x6FF644 VA: 0x6FF644
	public void .ctor() { }
}

// Namespace: SYBO.Subway.Analytics
[Serializable]
public class TabNavigation // TypeDefIndex: 11814
{
	// Fields
	public ViewConfigId ViewConfigId; // 0x8
	public string Name; // 0xC

	// Methods

	// RVA: 0x809A10 Offset: 0x809A10 VA: 0x809A10
	public bool Equals(TabNavigation other) { }

	// RVA: 0x809A64 Offset: 0x809A64 VA: 0x809A64
	public void .ctor() { }
}

// Namespace: SYBO.Subway.Analytics
public class ATTPromptResponse : AnalyticsDataEvent // TypeDefIndex: 11815
{
	// Fields
	private const string Outcome = "outcome";

	// Methods

	// RVA: 0x99BCEC Offset: 0x99BCEC VA: 0x99BCEC
	public void .ctor() { }

	// RVA: 0x99BD84 Offset: 0x99BD84 VA: 0x99BD84
	public AnalyticsDataEvent Configure(ATTrackingManagerAuthorizationStatus status) { }

	// RVA: 0x99BDF8 Offset: 0x99BDF8 VA: 0x99BDF8 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class ATTPromptShow : AnalyticsDataEvent // TypeDefIndex: 11816
{
	// Methods

	// RVA: 0x99BF64 Offset: 0x99BF64 VA: 0x99BF64
	public void .ctor() { }

	// RVA: 0x99BFFC Offset: 0x99BFFC VA: 0x99BFFC
	public AnalyticsDataEvent Configure() { }

	// RVA: 0x99C018 Offset: 0x99C018 VA: 0x99C018 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class AchievementCollectedEvent : AnalyticsDataEvent // TypeDefIndex: 11817
{
	// Fields
	private const string KeysCollected = "keys_collected";
	private const string Type = "type";
	private const string Tier = "tier";

	// Methods

	// RVA: 0x9A29A4 Offset: 0x9A29A4 VA: 0x9A29A4
	public void .ctor() { }

	// RVA: 0x9A2A3C Offset: 0x9A2A3C VA: 0x9A2A3C
	public AnalyticsDataEvent Configure(string type, int goal, int currentTier, int nextValue) { }

	// RVA: 0x9A2B4C Offset: 0x9A2B4C VA: 0x9A2B4C Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class BootstrapCompletedEvent : AnalyticsDataEvent // TypeDefIndex: 11818
{
	// Fields
	private const string LoadingTime = "loading_time";
	private const string NetworkLatency = "network_latency";
	private const string Online = "online";
	private const string RegionKey = "region";
	private const string ConsentKey = "consent";
	private const string AttKey = "att";
	private const string AgeKey = "age";
	private long _loadingTime; // 0x10

	// Methods

	// RVA: 0x6C313C Offset: 0x6C313C VA: 0x6C313C
	public void .ctor() { }

	// RVA: 0x6C31D4 Offset: 0x6C31D4 VA: 0x6C31D4 Slot: 6
	public override string GetAutomatedTestMarketKey() { }

	// RVA: 0x6C31DC Offset: 0x6C31DC VA: 0x6C31DC Slot: 5
	public override long GetAutomatedTestMarkerValue() { }

	// RVA: 0x6C31E4 Offset: 0x6C31E4 VA: 0x6C31E4 Slot: 4
	public override bool MarkerInAutomatedTest() { }

	// RVA: 0x6C31EC Offset: 0x6C31EC VA: 0x6C31EC
	public AnalyticsDataEvent Configure(string consent, int att, int age, string region, bool isOnline, int latency, long loadingTime) { }

	// RVA: 0x6C33B8 Offset: 0x6C33B8 VA: 0x6C33B8 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class BootstrapFailedEvent : AnalyticsDataEvent // TypeDefIndex: 11819
{
	// Fields
	private const string Step = "step";
	private const string Stage = "stage";
	private string _step; // 0x10
	private string _stage; // 0x14

	// Methods

	// RVA: 0x6C41A8 Offset: 0x6C41A8 VA: 0x6C41A8
	public void .ctor() { }

	// RVA: 0x6C4240 Offset: 0x6C4240 VA: 0x6C4240 Slot: 6
	public override string GetAutomatedTestMarketKey() { }

	// RVA: 0x6C429C Offset: 0x6C429C VA: 0x6C429C Slot: 5
	public override long GetAutomatedTestMarkerValue() { }

	// RVA: 0x6C42A8 Offset: 0x6C42A8 VA: 0x6C42A8 Slot: 4
	public override bool MarkerInAutomatedTest() { }

	// RVA: 0x6C42B0 Offset: 0x6C42B0 VA: 0x6C42B0
	public AnalyticsDataEvent Configure(string step, string stage) { }

	// RVA: 0x6C4360 Offset: 0x6C4360 VA: 0x6C4360 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class BootstrapStartedEvent : AnalyticsDataEvent // TypeDefIndex: 11820
{
	// Methods

	// RVA: 0x6C6DC8 Offset: 0x6C6DC8 VA: 0x6C6DC8
	public void .ctor() { }

	// RVA: 0x6C6E60 Offset: 0x6C6E60 VA: 0x6C6E60 Slot: 6
	public override string GetAutomatedTestMarketKey() { }

	// RVA: 0x6C6E68 Offset: 0x6C6E68 VA: 0x6C6E68 Slot: 4
	public override bool MarkerInAutomatedTest() { }

	// RVA: 0x6C6E70 Offset: 0x6C6E70 VA: 0x6C6E70
	public AnalyticsDataEvent Configure() { }

	// RVA: 0x6C6E8C Offset: 0x6C6E8C VA: 0x6C6E8C Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class BootstrapStepEvent : AnalyticsDataEvent // TypeDefIndex: 11821
{
	// Fields
	private const string LoadingTime = "loading_time";
	private const string Step = "step";
	private const string Status = "status";
	private int _status; // 0x10
	private long _loadingTime; // 0x18
	private string _step; // 0x20

	// Methods

	// RVA: 0x6C707C Offset: 0x6C707C VA: 0x6C707C
	public void .ctor() { }

	// RVA: 0x6C7114 Offset: 0x6C7114 VA: 0x6C7114
	public static AnalyticsDataEvent AsStart(string step) { }

	// RVA: 0x6C723C Offset: 0x6C723C VA: 0x6C723C
	public static AnalyticsDataEvent AsDone(string step, long loadingTime) { }

	// RVA: 0x6C73CC Offset: 0x6C73CC VA: 0x6C73CC Slot: 4
	public override bool MarkerInAutomatedTest() { }

	// RVA: 0x6C73D4 Offset: 0x6C73D4 VA: 0x6C73D4 Slot: 5
	public override long GetAutomatedTestMarkerValue() { }

	// RVA: 0x6C73DC Offset: 0x6C73DC VA: 0x6C73DC Slot: 6
	public override string GetAutomatedTestMarketKey() { }

	// RVA: 0x6C718C Offset: 0x6C718C VA: 0x6C718C
	public AnalyticsDataEvent Configure(string step, int status) { }

	// RVA: 0x6C72CC Offset: 0x6C72CC VA: 0x6C72CC
	public AnalyticsDataEvent Configure(string step, int status, long loadingTime) { }

	// RVA: 0x6C7460 Offset: 0x6C7460 VA: 0x6C7460 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class BoxOpenedEvent : AnalyticsDataEvent // TypeDefIndex: 11822
{
	// Fields
	private const string BoxType = "box_type";

	// Methods

	// RVA: 0x6CA2A8 Offset: 0x6CA2A8 VA: 0x6CA2A8
	public void .ctor() { }

	// RVA: 0x6CA340 Offset: 0x6CA340 VA: 0x6CA340
	public AnalyticsDataEvent Configure(string id, RewardOrigin origin) { }

	// RVA: 0x6CA46C Offset: 0x6CA46C VA: 0x6CA46C Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class CurrencyReceivedEvent : AnalyticsDataEvent // TypeDefIndex: 11823
{
	// Methods

	// RVA: 0x629300 Offset: 0x629300 VA: 0x629300
	public void .ctor() { }

	// RVA: 0x629398 Offset: 0x629398 VA: 0x629398
	public AnalyticsDataEvent Configure(CurrencyType currency, int amount, RewardOrigin source, int ownedTotal) { }

	// RVA: 0x62952C Offset: 0x62952C VA: 0x62952C Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class CurrencySpentEvent : AnalyticsDataEvent // TypeDefIndex: 11824
{
	// Fields
	private const string CurrencySpent = "currency_spent";
	private const string ProductType = "product_type";
	private const string ProductId = "product_id";
	private const string ItemQuantity = "item_quantity";

	// Methods

	// RVA: 0x62AD78 Offset: 0x62AD78 VA: 0x62AD78
	public void .ctor() { }

	// RVA: 0x62AE10 Offset: 0x62AE10 VA: 0x62AE10
	public AnalyticsDataEvent Configure(CurrencyType currencyType, int cost, int currentBalance, int currentBalanceInRun, string productType, string productId, int quantity) { }

	// RVA: 0x62AFCC Offset: 0x62AFCC VA: 0x62AFCC
	public AnalyticsDataEvent Configure(ProductData productData, int currentBalance, int currentBalanceInRun) { }

	// RVA: 0x62B1C0 Offset: 0x62B1C0 VA: 0x62B1C0 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class DataConsentEvent : AnalyticsDataEvent // TypeDefIndex: 11825
{
	// Fields
	private const string Given = "Given";
	private const string Refused = "Refused";
	private const string NotAsked = "NotAsked";
	private const string Outcome = "outcome";

	// Methods

	// RVA: 0x6368DC Offset: 0x6368DC VA: 0x6368DC
	public void .ctor() { }

	// RVA: 0x636974 Offset: 0x636974 VA: 0x636974
	public AnalyticsDataEvent Configure(ConsentStatus outcome) { }

	// RVA: 0x636A5C Offset: 0x636A5C VA: 0x636A5C Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class DataHandlingEvent : AnalyticsDataEvent // TypeDefIndex: 11826
{
	// Fields
	public const string TermsOfUse = "TermsOfUse";
	public const string PrivacyPolicy = "PrivacyPolicy";
	public const string Confirm = "Confirm";
	public const string Action = "action";

	// Methods

	// RVA: 0x637DC4 Offset: 0x637DC4 VA: 0x637DC4
	public void .ctor() { }

	// RVA: 0x637E5C Offset: 0x637E5C VA: 0x637E5C
	public AnalyticsDataEvent Configure(string action) { }

	// RVA: 0x637ED0 Offset: 0x637ED0 VA: 0x637ED0 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class DeviceInfoEvent : AnalyticsDataEvent // TypeDefIndex: 11827
{
	// Fields
	private const string ScreenHeight = "screen_height";
	private const string ScreenWidth = "screen_width";
	private const string ScreenPpi = "screen_ppi";
	private const string Gpu = "gpu";
	private const string GpuAPI = "gpu_api";
	private const string GpuRam = "gpu_ram";
	private const string GpuShaderLevel = "gpu_shader_level";
	private const string GpuMaxTextureSize = "gpu_max_texture_size";
	private const string CpuName = "cpu";
	private const string CpuThreads = "cpu_threads";
	private const string CpuFrequency = "cpu_frequency";
	private const string SystemMemory = "system_memory";
	private const string SupportsInstancing = "supports_instancing";

	// Methods

	// RVA: 0x60CF00 Offset: 0x60CF00 VA: 0x60CF00
	public void .ctor() { }

	// RVA: 0x60CF98 Offset: 0x60CF98 VA: 0x60CF98
	public AnalyticsDataEvent Configure() { }

	// RVA: 0x60D34C Offset: 0x60D34C VA: 0x60D34C
	private string GetTrimmedGPUName() { }

	// RVA: 0x60D4E4 Offset: 0x60D4E4 VA: 0x60D4E4 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class FTUEStepEvent : AnalyticsDataEvent // TypeDefIndex: 11828
{
	// Fields
	private const string Step = "step";

	// Methods

	// RVA: 0x964F90 Offset: 0x964F90 VA: 0x964F90
	public void .ctor() { }

	// RVA: 0x965028 Offset: 0x965028 VA: 0x965028
	public AnalyticsDataEvent Configure(FTUEStep step) { }

	// RVA: 0x965110 Offset: 0x965110 VA: 0x965110 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public enum FTUEStep // TypeDefIndex: 11829
{
	// Fields
	public int value__; // 0x0
	public const FTUEStep None = 0;
	public const FTUEStep TapToPlay = 1;
	public const FTUEStep Jump1 = 2;
	public const FTUEStep Jump2 = 3;
	public const FTUEStep Roll1 = 4;
	public const FTUEStep Roll2 = 5;
	public const FTUEStep Left1 = 6;
	public const FTUEStep Right1 = 7;
	public const FTUEStep Right2 = 8;
	public const FTUEStep Left2 = 9;
	public const FTUEStep FirstHighScore = 10;
	public const FTUEStep UseHoverboard = 11;
	public const FTUEStep TokenBoxPopup = 12;
	public const FTUEStep TokenBoxClaimed = 13;
	public const FTUEStep GreatRun = 14;
	public const FTUEStep ConnectAndCollect = 15;
	public const FTUEStep NeedHelpHoverboards = 16;
	public const FTUEStep PlayWithFriends = 17;
	public const FTUEStep RateSubwaySurfers = 18;
	public const FTUEStep GetHigherScores = 19;
	public const FTUEStep DataHandleShown = 20;
	public const FTUEStep SyncProgress = 21;
}

// Namespace: SYBO.Subway.Analytics
public class SendFTUEStepEvent : MonoBehaviour // TypeDefIndex: 11830
{
	// Fields
	private FTUEStepEvent _ftueStepAnalyticsEvent; // 0xC
	[SerializeField] // RVA: 0x3AB618 Offset: 0x3AB618 VA: 0x3AB618
	private FTUEStep _step; // 0x10

	// Methods

	// RVA: 0x5A9EC8 Offset: 0x5A9EC8 VA: 0x5A9EC8
	public void SendAnalyticsEvent() { }

	// RVA: 0x5A9F38 Offset: 0x5A9F38 VA: 0x5A9F38
	public void .ctor() { }
}

// Namespace: SYBO.Subway.Analytics
public class GameEndedEvent : AnalyticsDataEvent // TypeDefIndex: 11831
{
	// Fields
	private const string RunTime = "run_time";
	private const string HoverboardsUsed = "hoverboards_used";
	private const string HoverboardHits = "hoverboard_hits";
	private const string HeadstartsUsed = "headstarts_used";
	private const string ScoreBoostersUsed = "score_boosters_used";
	private const string CoinsCollected = "coins_collected";
	private const string KeysCollected = "keys_collected";
	private const string BoxesCollected = "boxes_collected";
	private const string TokenCollected = "tokens_collected";
	private const string Score = "score";
	private const string LettersCollected = "letters_collected";
	private const string DoubleCoin = "double_coin";
	private const string Stumbles = "stumbles";
	private const string RunSpeed = "run_speed";
	private const string ChallengeSetsActive = "challenge_sets_active";
	private const string TotalKeyRevives = "key_revives";
	private const string TotalAdRevives = "ad_revives";

	// Methods

	// RVA: 0x586A5C Offset: 0x586A5C VA: 0x586A5C
	public void .ctor() { }

	// RVA: 0x586AF4 Offset: 0x586AF4 VA: 0x586AF4
	public AnalyticsDataEvent Configure(RunStats runStats) { }

	// RVA: 0x5871C8 Offset: 0x5871C8 VA: 0x5871C8 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public enum RunEndedReason // TypeDefIndex: 11832
{
	// Fields
	public int value__; // 0x0
	public const RunEndedReason None = 0;
	public const RunEndedReason Hit = 1;
	public const RunEndedReason Stumble = 2;
	public const RunEndedReason Leave = 3;
	public const RunEndedReason Quit = 4;
	public const RunEndedReason OutOfTime = 5;
}

// Namespace: SYBO.Subway.Analytics
public class GameStartedEvent : AnalyticsDataEvent // TypeDefIndex: 11833
{
	// Fields
	private const string Character = "character";
	private const string CharacterOutfit = "character_outfit";
	private const string Board = "board";
	private const string BoardAbility = "board_ability";
	private const string ScoreMultiplier = "score_multiplier";
	private const string AdditionalScoreMultipliers = "additional_score_multipliers";
	private const string ChallengeSetsActive = "challenge_sets_active";

	// Methods

	// RVA: 0x58C908 Offset: 0x58C908 VA: 0x58C908
	public void .ctor() { }

	// RVA: 0x58C9A0 Offset: 0x58C9A0 VA: 0x58C9A0
	public AnalyticsDataEvent Configure(HoverboardSystem hoverboardSystem, RunStats runStats) { }

	// RVA: 0x58CEC4 Offset: 0x58CEC4 VA: 0x58CEC4 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class PermanentlyUnlockedEvent : AnalyticsDataEvent // TypeDefIndex: 11834
{
	// Fields
	private const string ItemType = "item_type";
	private const string ItemId = "item_id";

	// Methods

	// RVA: 0x880EDC Offset: 0x880EDC VA: 0x880EDC
	public void .ctor() { }

	// RVA: 0x880F74 Offset: 0x880F74 VA: 0x880F74
	public AnalyticsDataEvent Configure(AnalyticsProductType type, string itemId, RewardOrigin origin) { }

	// RVA: 0x881130 Offset: 0x881130 VA: 0x881130 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class PopupClosedEvent : AnalyticsDataEvent // TypeDefIndex: 11835
{
	// Fields
	public const string ActionDismiss = "Dismiss";
	public const string ActionClaim = "Claim";
	public const string ActionTimedOut = "TimedOut";
	public const string ActionDoubleUp = "DoubleUp";
	private const string Action = "action";

	// Methods

	// RVA: 0x5C9E94 Offset: 0x5C9E94 VA: 0x5C9E94
	public void .ctor() { }

	// RVA: 0x5C9F2C Offset: 0x5C9F2C VA: 0x5C9F2C
	public AnalyticsDataEvent Configure(string popupId, ViewConfig viewConfig, string action) { }

	// RVA: 0x5CA020 Offset: 0x5CA020 VA: 0x5CA020 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class PopupDisplayedEvent : AnalyticsDataEvent // TypeDefIndex: 11836
{
	// Methods

	// RVA: 0x5CAD84 Offset: 0x5CAD84 VA: 0x5CAD84
	public void .ctor() { }

	// RVA: 0x5CAE1C Offset: 0x5CAE1C VA: 0x5CAE1C
	public AnalyticsDataEvent Configure(string popupId, ViewConfig viewConfig) { }

	// RVA: 0x5CAEDC Offset: 0x5CAEDC VA: 0x5CAEDC Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class PromoCodeRedeemedEvent : AnalyticsDataEvent // TypeDefIndex: 11837
{
	// Fields
	private const string PromoCode = "promocode";

	// Methods

	// RVA: 0x649A8C Offset: 0x649A8C VA: 0x649A8C
	public void .ctor() { }

	// RVA: 0x649B24 Offset: 0x649B24 VA: 0x649B24
	public AnalyticsDataEvent Configure(string promoCode) { }

	// RVA: 0x649B98 Offset: 0x649B98 VA: 0x649B98 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class ReviveOfferedEvent : AnalyticsDataEvent // TypeDefIndex: 11838
{
	// Fields
	private const string Revived = "revived";
	private const string ReviveChoice = "revive_choice";
	private const string RevivalBonus = "revival_bonus";
	private const string KeyReviveOffered = "key_revive_offered";
	private const string AdReviveOffered = "ad_revive_offered";
	private const string BonusReviveOffered = "bonus_revive_offered";
	private const string ReviveCommunicationOffered = "communication_offered";
	private const string ReviveCommunicationType = "communication_type";
	private const string ReviveCommunicationValue = "communication_value";
	private const string Price = "price";
	private const string BonusNumber = "bonus_number";
	private const string BonusItemCount = "bonus_item_count";
	private const string BundleId = "bundle_id";

	// Methods

	// RVA: 0x916F90 Offset: 0x916F90 VA: 0x916F90
	public void .ctor() { }

	// RVA: 0x917028 Offset: 0x917028 VA: 0x917028
	public AnalyticsDataEvent Configure(ReviveChoiceInfo choiceInfo, int currentGameNumber, int runNumber, bool hasReviveHint, string reviveHintType, long reviveHintValue) { }

	// RVA: 0x917544 Offset: 0x917544 VA: 0x917544 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public enum ReviveChoiceType // TypeDefIndex: 11839
{
	// Fields
	public int value__; // 0x0
	public const ReviveChoiceType None = 0;
	public const ReviveChoiceType Key = 1;
	public const ReviveChoiceType Ad = 2;
	public const ReviveChoiceType Ad_With_Bonus = 3;
	public const ReviveChoiceType Multiple_Ad_With_Bonus = 4;
}

// Namespace: SYBO.Subway.Analytics
public class RunFinishedEvent : AnalyticsDataEvent // TypeDefIndex: 11840
{
	// Fields
	private const string RunTime = "run_time";
	private const string EndReason = "end_reason";
	private const string HoverboardsUsed = "hoverboards_used";
	private const string HoverboardHits = "hoverboard_hits";
	private const string HeadstartsUsed = "headstarts_used";
	private const string ScoreBoostersUsed = "score_boosters_used";
	private const string CoinsCollected = "coins_collected";
	private const string KeysCollected = "keys_collected";
	private const string BoxesCollected = "boxes_collected";
	private const string TokenCollected = "tokens_collected";
	private const string Score = "score";
	private const string LettersCollected = "letters_collected";
	private const string DoubleCoin = "double_coin";
	private const string Stumbles = "stumbles";
	private const string RunSpeed = "run_speed";
	private const string AvgFps = "avg_fps";
	private const string ChallengeSetsActive = "challenge_sets_active";
	private const string TimeBoostersCollected = "time_boosters_collected";

	// Methods

	// RVA: 0x9427E8 Offset: 0x9427E8 VA: 0x9427E8
	public void .ctor() { }

	// RVA: 0x942880 Offset: 0x942880 VA: 0x942880
	public AnalyticsDataEvent Configure(RunEndedReason endedReason, RunStats runStats) { }

	// RVA: 0x942EC8 Offset: 0x942EC8 VA: 0x942EC8 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: 
public enum SaveGameTransferEvent.TransferStatus // TypeDefIndex: 11841
{
	// Fields
	public int value__; // 0x0
	public const SaveGameTransferEvent.TransferStatus None = 0;
	public const SaveGameTransferEvent.TransferStatus Requested = 1;
	public const SaveGameTransferEvent.TransferStatus Failed = 2;
	public const SaveGameTransferEvent.TransferStatus Successful = 3;
}

// Namespace: SYBO.Subway.Analytics
public class SaveGameTransferEvent : AnalyticsDataEvent // TypeDefIndex: 11842
{
	// Fields
	private const string TransferLocalDescription = "Local";
	private const string TransferCloudDescription = "Cloud";
	private const string Status = "status";
	private const string Transfer = "transfer";

	// Methods

	// RVA: 0x956EF8 Offset: 0x956EF8 VA: 0x956EF8
	public void .ctor() { }

	// RVA: 0x956F90 Offset: 0x956F90 VA: 0x956F90
	public AnalyticsDataEvent Configure(bool isCloudTransfer, SaveGameTransferEvent.TransferStatus status) { }

	// RVA: 0x957100 Offset: 0x957100 VA: 0x957100 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class ScreenShownEvent : AnalyticsDataEvent // TypeDefIndex: 11843
{
	// Fields
	private const string NextScreen = "next_screen";
	private const string PreviousScreen = "previous_screen";
	private const string PreviousScreenTimeMS = "previous_screen_time_msec";
	private const string PreviousScreenData = "previous_screen_data";
	private const string NextScreenData = "next_screen_data";

	// Methods

	// RVA: 0xBA7C28 Offset: 0xBA7C28 VA: 0xBA7C28
	public void .ctor() { }

	// RVA: 0xBA7CC0 Offset: 0xBA7CC0 VA: 0xBA7CC0
	public AnalyticsDataEvent Configure(string nextScreen, int previousScreenTimeMS, string nextScreenData, string previousScreen) { }

	// RVA: 0xBA7E44 Offset: 0xBA7E44 VA: 0xBA7E44 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public abstract class SharedFeatureBaseEvent : AnalyticsDataEvent // TypeDefIndex: 11844
{
	// Fields
	protected const string NameUnlocked = "feature_rw_unlock";
	protected const string NameClaimed = "feature_rw_claim";
	protected const string FeatureOptIn = "feature_optin";
	protected const string FeatureIdKey = "feature_id";
	protected const string FeatureSubIdKey = "feature_sub_id";
	private const string RequirementType = "req_type";
	private const string RequirementValue = "req_val";
	private const string RequirementReachValue = "req_reach_val";
	private const string ScoreMultiplier = "score_multiplier";
	private const string ClaimType = "claim_type";
	protected const string Location = "location";
	private const string TierNo = "tier_no";
	private const string Tiers = "tiers";
	private const string RequirementCondition = "req_condition";
	private const string UnlockType = "unlock_type";

	// Methods

	// RVA: 0x5B6494 Offset: 0x5B6494 VA: 0x5B6494
	protected void .ctor(string name) { }

	// RVA: 0x5B6514 Offset: 0x5B6514 VA: 0x5B6514
	public SharedFeatureBaseEvent WithDefaultParameters(string featureId, string subFeatureId, string location) { }

	// RVA: 0x5B66AC Offset: 0x5B66AC VA: 0x5B66AC
	public SharedFeatureBaseEvent WithRequirements(SharedFeatureRequirementType requirementType, long reachedValue, int requirementValue) { }

	// RVA: 0x5B67FC Offset: 0x5B67FC VA: 0x5B67FC
	public SharedFeatureBaseEvent WithRequirements(SharedFeatureRequirementType requirementType, long reachedValue, int requirementValue, string requirementCondition) { }

	// RVA: 0x5B6980 Offset: 0x5B6980 VA: 0x5B6980
	public SharedFeatureBaseEvent WithRequirements(string requirementType, long reachedValue, int requirementValue, string requirementCondition) { }

	// RVA: 0x5B6A94 Offset: 0x5B6A94 VA: 0x5B6A94
	public SharedFeatureBaseEvent WithRunInfo(int runNumber) { }

	// RVA: 0x5B6B50 Offset: 0x5B6B50 VA: 0x5B6B50
	public SharedFeatureBaseEvent WithClaimInfo(SharedFeatureClaimType claimType, int tiers, int tier, SharedFeaturePlacementType placement) { }

	// RVA: 0x5B6C54 Offset: 0x5B6C54 VA: 0x5B6C54
	public SharedFeatureBaseEvent WithUnlockInfo(string unlockType, int tiers, int tier, SharedFeaturePlacementType placement) { }

	// RVA: 0x5B6D58 Offset: 0x5B6D58 VA: 0x5B6D58
	public SharedFeatureBaseEvent WithUnlockInfo(int tiers, int tier, SharedFeaturePlacementType placement) { }

	// RVA: 0x5B6E28 Offset: 0x5B6E28 VA: 0x5B6E28
	public SharedFeatureBaseEvent WithUnlockInfo(string unlockType, int tiers, int tier) { }

	// RVA: 0x5B6EF8 Offset: 0x5B6EF8 VA: 0x5B6EF8
	protected SharedFeatureBaseEvent WithOptinInfo(string featureId, string subFeatureId, string location, int tiers) { }

	// RVA: 0x5B70A4 Offset: 0x5B70A4 VA: 0x5B70A4
	protected AnalyticsDataEventValidator AddDefaultParametersValidators(AnalyticsDataEventValidator validator) { }

	// RVA: 0x5B75A4 Offset: 0x5B75A4 VA: 0x5B75A4
	protected AnalyticsDataEventValidator AddClaimParametersValidators(AnalyticsDataEventValidator validator) { }

	// RVA: 0x5B7AB8 Offset: 0x5B7AB8 VA: 0x5B7AB8
	protected AnalyticsDataEventValidator AddRunParametersValidators(AnalyticsDataEventValidator validator) { }

	// RVA: 0x5B7CF4 Offset: 0x5B7CF4 VA: 0x5B7CF4
	protected AnalyticsDataEventValidator AddRequirementsParametersValidators(AnalyticsDataEventValidator validator) { }

	// RVA: 0x5B8134 Offset: 0x5B8134 VA: 0x5B8134
	protected AnalyticsDataEventValidator AddOptInParametersValidators(AnalyticsDataEventValidator validator) { }
}

// Namespace: SYBO.Subway.Analytics
public enum SharedFeatureClaimType // TypeDefIndex: 11845
{
	// Fields
	public int value__; // 0x0
	public const SharedFeatureClaimType Default = 0;
	public const SharedFeatureClaimType ForcedAd = 1;
	public const SharedFeatureClaimType AdOptional_Accepted = 2;
	public const SharedFeatureClaimType AdOptional_Declined = 3;
	public const SharedFeatureClaimType ForcePaid = 4;
}

// Namespace: SYBO.Subway.Analytics
public enum SharedFeatureRequirementType // TypeDefIndex: 11846
{
	// Fields
	public int value__; // 0x0
	public const SharedFeatureRequirementType Coins = 0;
	public const SharedFeatureRequirementType Points = 1;
	public const SharedFeatureRequirementType Tokens = 2;
	public const SharedFeatureRequirementType Percent = 3;
}

// Namespace: SYBO.Subway.Analytics
public enum SharedFeatureEventType // TypeDefIndex: 11847
{
	// Fields
	public int value__; // 0x0
	public const SharedFeatureEventType Unlock = 1;
	public const SharedFeatureEventType Claim = 2;
}

// Namespace: SYBO.Subway.Analytics
public enum SharedFeaturePlacementType // TypeDefIndex: 11848
{
	// Fields
	public int value__; // 0x0
	public const SharedFeaturePlacementType Default = 0;
	public const SharedFeaturePlacementType MissionMenu = 1;
	public const SharedFeaturePlacementType PauseMenu = 2;
	public const SharedFeaturePlacementType EndRun = 3;
}

// Namespace: SYBO.Subway.Analytics
public enum SharedUnlockType // TypeDefIndex: 11849
{
	// Fields
	public int value__; // 0x0
	public const SharedUnlockType TokenPickups = 0;
	public const SharedUnlockType Keys = 1;
}

// Namespace: SYBO.Subway.Analytics
public class SocialProviderLinkEvent : AnalyticsDataEvent // TypeDefIndex: 11850
{
	// Fields
	public const string AccountLinkedStatusDescription = "account_linked";
	public const string AccountUnlinkedStatusDescription = "account_unlinked";
	public const string LinkFailedStatusDescription = "linking_failed";
	private const string SocialProvider = "social_provider";
	private const string Status = "status";

	// Methods

	// RVA: 0x7F0720 Offset: 0x7F0720 VA: 0x7F0720
	public void .ctor() { }

	// RVA: 0x7F07B8 Offset: 0x7F07B8 VA: 0x7F07B8
	public AnalyticsDataEvent Configure(AuthProvider provider, string status) { }

	// RVA: 0x7F0860 Offset: 0x7F0860 VA: 0x7F0860 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public abstract class TryItemEvent : AnalyticsDataEvent // TypeDefIndex: 11851
{
	// Fields
	private const string PurchaseDiscountCurrency = "purchase_discounted_currency";
	private const string PurchaseDiscountValueLocal = "purchase_discounted_value_local";
	private const string PurchaseFullType = "purchase_full_type";
	private const string PurchaseFullPrice = "purchase_full_price";
	private string offeredEventName; // 0x10
	private string claimedEventName; // 0x14

	// Methods

	// RVA: 0x729500 Offset: 0x729500 VA: 0x729500
	protected void .ctor(string name, string offeredEventName, string claimedEventName) { }

	// RVA: 0x7297F0 Offset: 0x7297F0 VA: 0x7297F0
	public AnalyticsDataEvent Configure(bool isPurchasePopup, bool didAccept, ProductData referenceProduct, ProductData discountProduct) { }

	// RVA: -1 Offset: -1 Slot: 8
	protected abstract string GetOfferedItem(ProductData product);

	// RVA: -1 Offset: -1 Slot: 9
	protected abstract string GetPopupId(bool isPurchasePopup);

	// RVA: 0x729B2C Offset: 0x729B2C VA: 0x729B2C Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class TryCharacterEvent : TryItemEvent // TypeDefIndex: 11852
{
	// Fields
	private const string CharacterOffered = "character_offered";
	private const string CharacterClaimed = "character_claimed";

	// Methods

	// RVA: 0x729670 Offset: 0x729670 VA: 0x729670
	public void .ctor() { }

	// RVA: 0x729710 Offset: 0x729710 VA: 0x729710 Slot: 8
	protected override string GetOfferedItem(ProductData product) { }

	// RVA: 0x72977C Offset: 0x72977C VA: 0x72977C Slot: 9
	protected override string GetPopupId(bool isPurchasePopup) { }
}

// Namespace: SYBO.Subway.Analytics
public class TryBoardEvent : TryItemEvent // TypeDefIndex: 11853
{
	// Fields
	private const string BoardOffered = "board_offered";
	private const string BoardClaimed = "board_claimed";

	// Methods

	// RVA: 0x729460 Offset: 0x729460 VA: 0x729460
	public void .ctor() { }

	// RVA: 0x729590 Offset: 0x729590 VA: 0x729590 Slot: 8
	protected override string GetOfferedItem(ProductData product) { }

	// RVA: 0x7295FC Offset: 0x7295FC VA: 0x7295FC Slot: 9
	protected override string GetPopupId(bool isPurchasePopup) { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F6CC Offset: 0x36F6CC VA: 0x36F6CC
private struct AbstractAnalyticsImplementation.<RequestIDFA>d__35 : IAsyncStateMachine // TypeDefIndex: 11854
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder <>t__builder; // 0x4
	public AbstractAnalyticsImplementation <>4__this; // 0x10
	public AdUserData userData; // 0x14
	private YieldAwaitable.YieldAwaiter <>u__1; // 0x18
	private TaskAwaiter<string> <>u__2; // 0x1C

	// Methods

	// RVA: 0x88C728 Offset: 0x88C728 VA: 0x88C728 Slot: 4
	private void MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BD414 Offset: 0x3BD414 VA: 0x3BD414
	// RVA: 0x88CDEC Offset: 0x88CDEC VA: 0x88CDEC Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
}

// Namespace: SYBO.Subway.Analytics
public abstract class AbstractAnalyticsImplementation // TypeDefIndex: 11855
{
	// Fields
	private const string LegacySampledValueKey = "sampledValueKey";
	private const string LegacyDidSampleRun = "didSampleRun";
	private const string LegacyIapConvertedKey = "IapConverted";
	private const string SampleDataFile = "sample_data.json";
	private FileStorage _storage; // 0x8
	private AnalyticsSampleConfiguration _sampleConfiguration; // 0xC
	protected bool _isEnabled; // 0x10
	private AnalyticsIdentifiers _analyticsIdentifiers; // 0x14
	private int _sampleValue; // 0x18
	private TaskCompletionSource<string> _idfaCompletionTask; // 0x1C

	// Properties
	public bool IsEnabled { get; }

	// Methods

	// RVA: 0x99C658 Offset: 0x99C658 VA: 0x99C658
	public bool get_IsEnabled() { }

	// RVA: 0x99C660 Offset: 0x99C660 VA: 0x99C660
	protected void .ctor() { }

	// RVA: 0x99C7B4 Offset: 0x99C7B4 VA: 0x99C7B4
	public AnalyticsIdentifiers GetIdentifiers() { }

	// RVA: 0x99C7BC Offset: 0x99C7BC VA: 0x99C7BC
	public void SetSampleValue(int sampleValue) { }

	// RVA: 0x99C7C4 Offset: 0x99C7C4 VA: 0x99C7C4
	public void Initialize() { }

	// RVA: 0x99CDD8 Offset: 0x99CDD8 VA: 0x99CDD8
	public void Configure(bool enabled, int sampledValue, bool iapConverted) { }

	// RVA: -1 Offset: -1 Slot: 4
	public abstract void SetExperimentProperties(string experiment, string variant);

	// RVA: -1 Offset: -1 Slot: 5
	protected abstract void OnSetIDFA(string vendorIdentifier);

	// RVA: -1 Offset: -1 Slot: 6
	protected abstract void OnSetIDFV(string vendorIdentifier);

	// RVA: -1 Offset: -1 Slot: 7
	protected abstract void SetSampledProperty(int sampledVal);

	// RVA: -1 Offset: -1 Slot: 8
	protected abstract void SetIAPConvertedProperty(bool converted);

	// RVA: 0x99CE64 Offset: 0x99CE64 VA: 0x99CE64
	public void LogSampledEvent(AnalyticsDataEvent evt) { }

	// RVA: 0x99CED0 Offset: 0x99CED0 VA: 0x99CED0
	public void LogEvent(AnalyticsDataEvent evt, bool force = False) { }

	// RVA: -1 Offset: -1 Slot: 9
	protected abstract void LogEventInternal(AnalyticsDataEvent evt);

	// RVA: 0x99CEF4 Offset: 0x99CEF4 VA: 0x99CEF4
	public void EnableCollection(bool value) { }

	// RVA: 0x99CEB0 Offset: 0x99CEB0 VA: 0x99CEB0
	public bool IsInternallySampled() { }

	// RVA: -1 Offset: -1 Slot: 10
	protected abstract void OnEnableCollection(bool value);

	// RVA: 0x99CE1C Offset: 0x99CE1C VA: 0x99CE1C
	private void SetIapConverted(bool converted) { }

	// RVA: 0x99D070 Offset: 0x99D070 VA: 0x99D070
	private bool IsSampled(int sampleValue) { }

	// RVA: 0x99D0B8 Offset: 0x99D0B8 VA: 0x99D0B8
	public bool IsIAPConverted() { }

	// RVA: 0x99CFA0 Offset: 0x99CFA0 VA: 0x99CFA0
	public int GetSample() { }

	// RVA: 0x99D0D8 Offset: 0x99D0D8 VA: 0x99D0D8
	private void SetSample(int sampledValue) { }

	// RVA: 0x99CBEC Offset: 0x99CBEC VA: 0x99CBEC
	private void SaveSample() { }

	// RVA: 0x99D120 Offset: 0x99D120 VA: 0x99D120
	public void ClearSample() { }

	[AsyncStateMachineAttribute] // RVA: 0x3BD3A8 Offset: 0x3BD3A8 VA: 0x3BD3A8
	// RVA: 0x99D1A8 Offset: 0x99D1A8 VA: 0x99D1A8
	public Task RequestIDFA(AdUserData userData) { }

	// RVA: 0x99D2DC Offset: 0x99D2DC VA: 0x99D2DC
	private void OnIDFARequestResponse(string advertisingId, bool trackingEnabled, string error) { }
}

// Namespace: SYBO.Subway.Analytics
[Serializable]
public class AnalyticsSampleConfiguration // TypeDefIndex: 11856
{
	// Fields
	[SerializedAsAttribute] // RVA: 0x3AB628 Offset: 0x3AB628 VA: 0x3AB628
	[DataMemberAttribute] // RVA: 0x3AB628 Offset: 0x3AB628 VA: 0x3AB628
	public bool DidSampleRun; // 0x8
	[SerializedAsAttribute] // RVA: 0x3AB690 Offset: 0x3AB690 VA: 0x3AB690
	[DataMemberAttribute] // RVA: 0x3AB690 Offset: 0x3AB690 VA: 0x3AB690
	public int SampleValue; // 0xC
	[SerializedAsAttribute] // RVA: 0x3AB6F8 Offset: 0x3AB6F8 VA: 0x3AB6F8
	[DataMemberAttribute] // RVA: 0x3AB6F8 Offset: 0x3AB6F8 VA: 0x3AB6F8
	public bool IsIAPConverted; // 0x10

	// Methods

	// RVA: 0x6FF6B4 Offset: 0x6FF6B4 VA: 0x6FF6B4
	public void Clear() { }

	// RVA: 0x6FF6C8 Offset: 0x6FF6C8 VA: 0x6FF6C8
	public void .ctor() { }
}

// Namespace: SYBO.Subway.Analytics
public class AnalyticsIdentifiers // TypeDefIndex: 11857
{
	// Fields
	public string IDFV; // 0x8
	public string IDFA; // 0xC
	public bool IDFASupported; // 0x10
	public bool IDFAEnabled; // 0x11
	public string IDFAError; // 0x14
	public bool Ready; // 0x18

	// Methods

	// RVA: 0x6FDC70 Offset: 0x6FDC70 VA: 0x6FDC70
	public void .ctor() { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F6DC Offset: 0x36F6DC VA: 0x36F6DC
private struct AnalyticsManager.<Initialize>d__9 : IAsyncStateMachine // TypeDefIndex: 11858
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncVoidMethodBuilder <>t__builder; // 0x4
	public AnalyticsManager <>4__this; // 0x14
	private TaskAwaiter <>u__1; // 0x18

	// Methods

	// RVA: 0x88F4AC Offset: 0x88F4AC VA: 0x88F4AC Slot: 4
	private void MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BD5F4 Offset: 0x3BD5F4 VA: 0x3BD5F4
	// RVA: 0x88F7E4 Offset: 0x88F7E4 VA: 0x88F7E4 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F6EC Offset: 0x36F6EC VA: 0x36F6EC
private struct AnalyticsManager.<RequestAdvertisingId>d__10 : IAsyncStateMachine // TypeDefIndex: 11859
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder <>t__builder; // 0x4
	public AnalyticsManager <>4__this; // 0x10
	public AdUserData userData; // 0x14
	private TaskAwaiter <>u__1; // 0x18

	// Methods

	// RVA: 0x88FA38 Offset: 0x88FA38 VA: 0x88FA38 Slot: 4
	private void MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BD604 Offset: 0x3BD604 VA: 0x3BD604
	// RVA: 0x88FC14 Offset: 0x88FC14 VA: 0x88FC14 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F6FC Offset: 0x36F6FC VA: 0x36F6FC
private struct AnalyticsManager.<OnNetworkChanged>d__11 : IAsyncStateMachine // TypeDefIndex: 11860
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncVoidMethodBuilder <>t__builder; // 0x4
	public bool status; // 0x14
	public AnalyticsManager <>4__this; // 0x18
	private TaskAwaiter <>u__1; // 0x1C

	// Methods

	// RVA: 0x88F7F0 Offset: 0x88F7F0 VA: 0x88F7F0 Slot: 4
	private void MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BD614 Offset: 0x3BD614 VA: 0x3BD614
	// RVA: 0x88FA2C Offset: 0x88FA2C VA: 0x88FA2C Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F70C Offset: 0x36F70C VA: 0x36F70C
private struct AnalyticsManager.<TryToInitialize>d__12 : IAsyncStateMachine // TypeDefIndex: 11861
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder <>t__builder; // 0x4
	public CancellationToken token; // 0x10
	public AnalyticsManager <>4__this; // 0x14
	private YieldAwaitable.YieldAwaiter <>u__1; // 0x18

	// Methods

	// RVA: 0x88FC20 Offset: 0x88FC20 VA: 0x88FC20 Slot: 4
	private void MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BD624 Offset: 0x3BD624 VA: 0x3BD624
	// RVA: 0x8901F8 Offset: 0x8901F8 VA: 0x8901F8 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
}

// Namespace: SYBO.Subway.Analytics
public class AnalyticsManager // TypeDefIndex: 11862
{
	// Fields
	private const int DefaultSampling = 100;
	[CompilerGeneratedAttribute] // RVA: 0x3AB760 Offset: 0x3AB760 VA: 0x3AB760
	private Action<AnalyticsDataEvent> OnEvent; // 0x8
	private AbstractAnalyticsImplementation _implementation; // 0xC
	private CancellationTokenSource _cancellationToken; // 0x10

	// Properties
	public bool IsEnabled { get; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x3BD424 Offset: 0x3BD424 VA: 0x3BD424
	// RVA: 0x6FDC78 Offset: 0x6FDC78 VA: 0x6FDC78
	public void add_OnEvent(Action<AnalyticsDataEvent> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x3BD434 Offset: 0x3BD434 VA: 0x3BD434
	// RVA: 0x6FDD24 Offset: 0x6FDD24 VA: 0x6FDD24
	public void remove_OnEvent(Action<AnalyticsDataEvent> value) { }

	// RVA: 0x6FDDD0 Offset: 0x6FDDD0 VA: 0x6FDDD0
	public bool get_IsEnabled() { }

	// RVA: 0x6FDDF0 Offset: 0x6FDDF0 VA: 0x6FDDF0
	public void .ctor() { }

	[AsyncStateMachineAttribute] // RVA: 0x3BD444 Offset: 0x3BD444 VA: 0x3BD444
	// RVA: 0x6FDE60 Offset: 0x6FDE60 VA: 0x6FDE60
	public void Initialize() { }

	[AsyncStateMachineAttribute] // RVA: 0x3BD4B0 Offset: 0x3BD4B0 VA: 0x3BD4B0
	// RVA: 0x6FDF1C Offset: 0x6FDF1C VA: 0x6FDF1C
	public Task RequestAdvertisingId(AdUserData userData) { }

	[AsyncStateMachineAttribute] // RVA: 0x3BD51C Offset: 0x3BD51C VA: 0x3BD51C
	// RVA: 0x6FE04C Offset: 0x6FE04C VA: 0x6FE04C
	private void OnNetworkChanged(bool status) { }

	[AsyncStateMachineAttribute] // RVA: 0x3BD588 Offset: 0x3BD588 VA: 0x3BD588
	// RVA: 0x6FE11C Offset: 0x6FE11C VA: 0x6FE11C
	private Task TryToInitialize(CancellationToken token) { }

	// RVA: 0x6FE248 Offset: 0x6FE248 VA: 0x6FE248
	public void LogSampledEvent(AnalyticsDataEvent evt) { }

	// RVA: 0x6F2E78 Offset: 0x6F2E78 VA: 0x6F2E78
	public void LogEvent(AnalyticsDataEvent evt) { }

	// RVA: 0x6FE2D0 Offset: 0x6FE2D0 VA: 0x6FE2D0
	public void LogEvent(AnalyticsDataEvent evt, bool force) { }

	// RVA: 0x6FE360 Offset: 0x6FE360 VA: 0x6FE360
	public void Configure(bool enabled, int sampledValue, bool iapConverted) { }

	// RVA: 0x6FE3AC Offset: 0x6FE3AC VA: 0x6FE3AC
	public int GetSample() { }

	// RVA: 0x6FE3D4 Offset: 0x6FE3D4 VA: 0x6FE3D4
	public bool GetIapConverted() { }

	// RVA: 0x6FE3FC Offset: 0x6FE3FC VA: 0x6FE3FC
	public AnalyticsIdentifiers GetIdentifiers() { }

	// RVA: 0x6FE474 Offset: 0x6FE474 VA: 0x6FE474
	public void SetExperimentProperties(string experiment, string variant) { }

	// RVA: 0x6FE4B4 Offset: 0x6FE4B4 VA: 0x6FE4B4
	public void ClearSample() { }
}

// Namespace: SYBO.Subway.Analytics
public abstract class AnalyticsDataEvent // TypeDefIndex: 11863
{
	// Fields
	private const string ScreenNumbersSeparator = ",";
	private const char ViewSeparator = '\x5f';
	private const string EventID = "event_id";
	private const string DefaultProduct = "default";
	protected const string Source = "source";
	protected const string Placement = "placement";
	protected const string Screen = "screen";
	protected const string Available = "available";
	protected const string Goal = "goal";
	protected const string GameNumber = "game_no";
	protected const string RunNumber = "run_no";
	protected const string SelectedCity = "selected_city";
	protected const string SeasonId = "season_id";
	protected const string PopupId = "popup_id";
	protected const string ScreenNumber = "screen_no";
	protected const string CurrencyType = "currency_type";
	protected const string CurrentyReceived = "currency_received";
	protected const string CurrencyBalanceAfter = "currency_balance_after";
	protected const string CurrencyBalanceAfterInRun = "currency_balance_after_in_run";
	protected const string SeasonHuntId = "season_hunt_id";
	protected const string SeasonHuntTokensRequired = "tokens_required";
	protected const string SeasonHuntRewardNumber = "reward_no";
	protected const string SeasonHuntTotalTokens = "total_tokens_required";
	protected const string SeasonHuntIsNextRewardTimegated = "next_reward_is_timegated";
	protected const string SeasonHuntIsPremium = "is_premium_track";
	private static readonly string[] AnalyticsDailyVideoAsPlacementID; // 0x0
	public string Name; // 0x8
	public List<Parameter> _parameters; // 0xC

	// Methods

	// RVA: 0x6F3064 Offset: 0x6F3064 VA: 0x6F3064
	public void .ctor(string name) { }

	// RVA: 0x6F57E4 Offset: 0x6F57E4 VA: 0x6F57E4
	protected void AddParameter(string key, long value) { }

	// RVA: 0x6F58A8 Offset: 0x6F58A8 VA: 0x6F58A8
	protected void AddParameter(string key, bool value) { }

	// RVA: 0x6F31CC Offset: 0x6F31CC VA: 0x6F31CC
	protected void AddParameter(string key, int value) { }

	// RVA: 0x6F5968 Offset: 0x6F5968 VA: 0x6F5968
	protected void AddParameter(string key, Nullable<int> value) { }

	// RVA: 0x6F5A38 Offset: 0x6F5A38 VA: 0x6F5A38
	protected void AddParameter(string key, float value) { }

	// RVA: 0x6F5B00 Offset: 0x6F5B00 VA: 0x6F5B00
	protected void AddParameter(string key, Decimal value) { }

	// RVA: 0x6F5C24 Offset: 0x6F5C24 VA: 0x6F5C24
	protected void AddParameter(string key, double value) { }

	// RVA: 0x6F5CE8 Offset: 0x6F5CE8 VA: 0x6F5CE8
	protected void AddParameter(string key, Nullable<double> value) { }

	// RVA: 0x6F5DBC Offset: 0x6F5DBC VA: 0x6F5DBC
	protected void AddParameter(string key, string value) { }

	// RVA: 0x6F3168 Offset: 0x6F3168 VA: 0x6F3168
	protected void Clear() { }

	// RVA: 0x6F5E68 Offset: 0x6F5E68 VA: 0x6F5E68
	public Parameter[] GetParameters() { }

	// RVA: 0x6F5F00 Offset: 0x6F5F00 VA: 0x6F5F00
	protected string GenerateEventId() { }

	// RVA: 0x6F6064 Offset: 0x6F6064 VA: 0x6F6064
	public string GetAnalyticsProductTypeDescription(ProductData product) { }

	// RVA: 0x6F6258 Offset: 0x6F6258 VA: 0x6F6258
	private bool CheckIfCharacterIsDefault(ProductData product) { }

	// RVA: 0x6F6354 Offset: 0x6F6354 VA: 0x6F6354
	private bool CheckIfHoverboardIsDefault(ProductData product) { }

	// RVA: 0x6F6440 Offset: 0x6F6440 VA: 0x6F6440
	public string GetCurrencyTypeDescription(CurrencyType type) { }

	// RVA: 0x6F66FC Offset: 0x6F66FC VA: 0x6F66FC Slot: 4
	public virtual bool MarkerInAutomatedTest() { }

	// RVA: 0x6F6704 Offset: 0x6F6704 VA: 0x6F6704 Slot: 5
	public virtual long GetAutomatedTestMarkerValue() { }

	// RVA: 0x6F6710 Offset: 0x6F6710 VA: 0x6F6710 Slot: 6
	public virtual string GetAutomatedTestMarketKey() { }

	// RVA: -1 Offset: -1 Slot: 7
	public abstract AnalyticsDataEventValidator GetValidator();

	// RVA: 0x6F6718 Offset: 0x6F6718 VA: 0x6F6718
	private static void .cctor() { }
}

// Namespace: SYBO.Subway.Analytics
public class AnalyticsValidator // TypeDefIndex: 11864
{
	// Fields
	private Dictionary<Type, Dictionary<string, AnalyticsDataEventValidator>> _eventValidators; // 0x8

	// Methods

	// RVA: 0x6FF6F0 Offset: 0x6FF6F0 VA: 0x6FF6F0
	public void .ctor() { }

	// RVA: 0x6FF780 Offset: 0x6FF780 VA: 0x6FF780
	public List<string> Validate(AnalyticsDataEvent evt) { }
}

// Namespace: SYBO.Subway.Analytics
public class NullAnalyticsDataEventValidator : AnalyticsDataEventValidator // TypeDefIndex: 11865
{
	// Methods

	// RVA: 0x879050 Offset: 0x879050 VA: 0x879050 Slot: 4
	public override List<string> Validate(string name, Dictionary<string, object> rawParameters) { }

	// RVA: 0x879194 Offset: 0x879194 VA: 0x879194
	public void .ctor() { }
}

// Namespace: SYBO.Subway.Analytics
public class AnalyticsDataEventValidator // TypeDefIndex: 11866
{
	// Fields
	private Dictionary<string, PropertyValidator[]> _parameterValidators; // 0x8
	private Dictionary<string, PropertyValidator> _parameterNullValidator; // 0xC
	private Dictionary<string, PropertyValidator> _typeValidator; // 0x10
	private Dictionary<string, bool> _parameterExistence; // 0x14

	// Methods

	// RVA: 0x6F33F4 Offset: 0x6F33F4 VA: 0x6F33F4
	public void .ctor() { }

	// RVA: -1 Offset: -1
	public AnalyticsDataEventValidator AddMandatoryNonNull<T>(string parameter, PropertyValidator[] validators) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1050B48 Offset: 0x1050B48 VA: 0x1050B48
	|-AnalyticsDataEventValidator.AddMandatoryNonNull<int>
	|
	|-RVA: 0x1050BA0 Offset: 0x1050BA0 VA: 0x1050BA0
	|-AnalyticsDataEventValidator.AddMandatoryNonNull<long>
	|
	|-RVA: 0x1050BF8 Offset: 0x1050BF8 VA: 0x1050BF8
	|-AnalyticsDataEventValidator.AddMandatoryNonNull<object>
	|-AnalyticsDataEventValidator.AddMandatoryNonNull<string>
	*/

	// RVA: -1 Offset: -1
	public AnalyticsDataEventValidator Add<T>(string parameter, bool mandatory, bool canBeNull, PropertyValidator[] validators) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1050468 Offset: 0x1050468 VA: 0x1050468
	|-AnalyticsDataEventValidator.Add<double>
	|
	|-RVA: 0x1050620 Offset: 0x1050620 VA: 0x1050620
	|-AnalyticsDataEventValidator.Add<int>
	|
	|-RVA: 0x10507D8 Offset: 0x10507D8 VA: 0x10507D8
	|-AnalyticsDataEventValidator.Add<long>
	|
	|-RVA: 0x1050990 Offset: 0x1050990 VA: 0x1050990
	|-AnalyticsDataEventValidator.Add<object>
	|-AnalyticsDataEventValidator.Add<string>
	*/

	// RVA: 0x6F68DC Offset: 0x6F68DC VA: 0x6F68DC
	protected List<string> DefaultFirebaseRelatedValidation(string name, Dictionary<string, object> rawParameters) { }

	// RVA: 0x6F6E24 Offset: 0x6F6E24 VA: 0x6F6E24 Slot: 4
	public virtual List<string> Validate(string name, Dictionary<string, object> rawParameters) { }
}

// Namespace: SYBO.Subway.Analytics
public abstract class PropertyValidator // TypeDefIndex: 11867
{
	// Methods

	// RVA: -1 Offset: -1 Slot: 4
	public abstract bool Validate(string key, object rawValue, out string error);

	// RVA: 0x653A68 Offset: 0x653A68 VA: 0x653A68
	protected void .ctor() { }
}

// Namespace: SYBO.Subway.Analytics
internal class PropertyNullValidator : PropertyValidator // TypeDefIndex: 11868
{
	// Methods

	// RVA: 0x653978 Offset: 0x653978 VA: 0x653978 Slot: 4
	public override bool Validate(string key, object rawValue, out string error) { }

	// RVA: 0x653A60 Offset: 0x653A60 VA: 0x653A60
	public void .ctor() { }
}

// Namespace: SYBO.Subway.Analytics
internal class PropertyTypeValidator<T> : PropertyValidator // TypeDefIndex: 11869
{
	// Fields
	private bool _canBeNull; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(bool canBeNull) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1A69958 Offset: 0x1A69958 VA: 0x1A69958
	|-PropertyTypeValidator<double>..ctor
	|
	|-RVA: 0x1A699E4 Offset: 0x1A699E4 VA: 0x1A699E4
	|-PropertyTypeValidator<int>..ctor
	|
	|-RVA: 0x1A69A70 Offset: 0x1A69A70 VA: 0x1A69A70
	|-PropertyTypeValidator<long>..ctor
	|
	|-RVA: 0x1CD2890 Offset: 0x1CD2890 VA: 0x1CD2890
	|-PropertyTypeValidator<object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public override bool Validate(string key, object rawValue, out string error) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1A69988 Offset: 0x1A69988 VA: 0x1A69988
	|-PropertyTypeValidator<double>.Validate
	|
	|-RVA: 0x1A69A14 Offset: 0x1A69A14 VA: 0x1A69A14
	|-PropertyTypeValidator<int>.Validate
	|
	|-RVA: 0x1A69AA0 Offset: 0x1A69AA0 VA: 0x1A69AA0
	|-PropertyTypeValidator<long>.Validate
	|
	|-RVA: 0x1CD28C0 Offset: 0x1CD28C0 VA: 0x1CD28C0
	|-PropertyTypeValidator<object>.Validate
	*/
}

// Namespace: SYBO.Subway.Analytics
internal abstract class PropertyValidator<T> : PropertyValidator // TypeDefIndex: 11870
{
	// Methods

	// RVA: -1 Offset: -1 Slot: 4
	public sealed override bool Validate(string key, object rawValue, out string error) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1CD2BE4 Offset: 0x1CD2BE4 VA: 0x1CD2BE4
	|-PropertyValidator<int>.Validate
	|
	|-RVA: 0x1CD2F64 Offset: 0x1CD2F64 VA: 0x1CD2F64
	|-PropertyValidator<object>.Validate
	*/

	// RVA: -1 Offset: -1 Slot: 5
	protected abstract bool OnValidate(string key, T value, out string error);
	/* GenericInstMethod :
	|
	|-RVA: -1 Offset: -1
	|-PropertyValidator<object>.OnValidate
	*/

	// RVA: -1 Offset: -1
	protected void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1CD2F3C Offset: 0x1CD2F3C VA: 0x1CD2F3C
	|-PropertyValidator<int>..ctor
	|
	|-RVA: 0x1CD32AC Offset: 0x1CD32AC VA: 0x1CD32AC
	|-PropertyValidator<object>..ctor
	*/
}

// Namespace: SYBO.Subway.Analytics
internal class PropertyValidatorBetween : PropertyValidator<int> // TypeDefIndex: 11871
{
	// Fields
	private int _min; // 0x8
	private int _max; // 0xC

	// Methods

	// RVA: 0x653B88 Offset: 0x653B88 VA: 0x653B88
	public void .ctor(int min, int max) { }

	// RVA: 0x653BF0 Offset: 0x653BF0 VA: 0x653BF0 Slot: 5
	protected override bool OnValidate(string key, int value, out string error) { }
}

// Namespace: SYBO.Subway.Analytics
internal class PropertyValidatorAsIntBool : PropertyValidator<int> // TypeDefIndex: 11872
{
	// Methods

	// RVA: 0x653A78 Offset: 0x653A78 VA: 0x653A78 Slot: 5
	protected override bool OnValidate(string key, int value, out string error) { }

	// RVA: 0x653B30 Offset: 0x653B30 VA: 0x653B30
	public void .ctor() { }
}

// Namespace: SYBO.Subway.Analytics
internal class PropertyValidatorGreaterThan : PropertyValidator<int> // TypeDefIndex: 11873
{
	// Fields
	private int _min; // 0x8

	// Methods

	// RVA: 0x653E48 Offset: 0x653E48 VA: 0x653E48
	public void .ctor(int min) { }

	// RVA: 0x653EA8 Offset: 0x653EA8 VA: 0x653EA8 Slot: 5
	protected override bool OnValidate(string key, int value, out string error) { }
}

// Namespace: SYBO.Subway.Analytics
public class FirebaseAnalyticsImplementation : AbstractAnalyticsImplementation // TypeDefIndex: 11874
{
	// Fields
	private const string IDFA = "IDFA";
	private const string IDFV = "vendor_id";
	private const string Experiment = "experiment";
	private const string Variant = "variant";
	private const string SampledValue = "sampled_value";
	private const string IapConverted = "iap_converted";
	private const string DEFAULT_EXPERIMENT = "default";
	private const string DEFAULT_VARIANT = "default";
	private ConcurrentStack<AnalyticsDataEvent> _enqueuedEvents; // 0x20

	// Methods

	// RVA: 0x96BD64 Offset: 0x96BD64 VA: 0x96BD64 Slot: 4
	public override void SetExperimentProperties(string experiment, string variant) { }

	// RVA: 0x96BF14 Offset: 0x96BF14 VA: 0x96BF14 Slot: 5
	protected override void OnSetIDFA(string advertisingId) { }

	// RVA: 0x96BFD0 Offset: 0x96BFD0 VA: 0x96BFD0 Slot: 6
	protected override void OnSetIDFV(string vendorIdentifier) { }

	// RVA: 0x96C08C Offset: 0x96C08C VA: 0x96C08C Slot: 7
	protected override void SetSampledProperty(int sampledVal) { }

	// RVA: 0x96C148 Offset: 0x96C148 VA: 0x96C148 Slot: 8
	protected override void SetIAPConvertedProperty(bool converted) { }

	// RVA: 0x96C204 Offset: 0x96C204 VA: 0x96C204 Slot: 10
	protected override void OnEnableCollection(bool value) { }

	// RVA: 0x96C3A0 Offset: 0x96C3A0 VA: 0x96C3A0 Slot: 9
	protected override void LogEventInternal(AnalyticsDataEvent evt) { }

	// RVA: 0x96C49C Offset: 0x96C49C VA: 0x96C49C
	public void .ctor() { }
}

// Namespace: SYBO.Subway.Analytics
public class AdImpressionDataEvent : AnalyticsDataEvent // TypeDefIndex: 11875
{
	// Fields
	private const string Ab = "ab";
	private const string Country = "country";
	private const string Precision = "precision";
	private const string AdNetwork = "ad_network";
	private const string AdUnit = "ad_unit";
	private const string AuctionId = "auction_id";
	private const string InstanceId = "instance_id";
	private const string InstanceName = "instance_name";
	private const string SegmentName = "segment_name";
	private const string EncryptedCPM = "encrypted_cpm";
	private const string Revenue = "revenue";
	private const string ConversionValue = "conversion_value";
	private const string LifetimeRevenue = "lifetime_revenue";
	private const string DisplayTimeMs = "display_time_ms";

	// Methods

	// RVA: 0x9AB230 Offset: 0x9AB230 VA: 0x9AB230
	public void .ctor() { }

	// RVA: 0x9AB2C8 Offset: 0x9AB2C8 VA: 0x9AB2C8
	public AnalyticsDataEvent Configure(ImpressionData data) { }

	// RVA: 0x9AB774 Offset: 0x9AB774 VA: 0x9AB774 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class AdLoadingTimeDataEvent : AnalyticsDataEvent // TypeDefIndex: 11876
{
	// Fields
	private const string LoadingMs = "loading_ms";

	// Methods

	// RVA: 0x9AC6E0 Offset: 0x9AC6E0 VA: 0x9AC6E0
	public void .ctor() { }

	// RVA: 0x9AC778 Offset: 0x9AC778 VA: 0x9AC778
	public AnalyticsDataEvent Configure(long time) { }

	// RVA: 0x9AC800 Offset: 0x9AC800 VA: 0x9AC800 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class AdMeterSharedEvent : SharedFeatureBaseEvent // TypeDefIndex: 11877
{
	// Fields
	private const string AdMeterFeatureID = "ad_meter";

	// Methods

	// RVA: 0x9AE03C Offset: 0x9AE03C VA: 0x9AE03C
	public static SharedFeatureBaseEvent AsUnlock(string meterId) { }

	// RVA: 0x9AE17C Offset: 0x9AE17C VA: 0x9AE17C
	public static SharedFeatureBaseEvent AsClaim(string meterId) { }

	// RVA: 0x9AE2B4 Offset: 0x9AE2B4 VA: 0x9AE2B4 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }

	// RVA: 0x9AE174 Offset: 0x9AE174 VA: 0x9AE174
	private void .ctor(string name) { }
}

// Namespace: SYBO.Subway.Analytics
public class InterstitialAdServedEvent : AnalyticsDataEvent // TypeDefIndex: 11878
{
	// Methods

	// RVA: 0xA3C21C Offset: 0xA3C21C VA: 0xA3C21C
	public void .ctor() { }

	// RVA: 0xA3C33C Offset: 0xA3C33C VA: 0xA3C33C
	public AnalyticsDataEvent Configure(string placementId, bool available) { }

	// RVA: 0xA3C3E4 Offset: 0xA3C3E4 VA: 0xA3C3E4 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class RewardedAdClickedEvent : RewardedAdEvent // TypeDefIndex: 11879
{
	// Methods

	// RVA: 0x92017C Offset: 0x92017C VA: 0x92017C
	public void .ctor() { }

	// RVA: 0x920254 Offset: 0x920254 VA: 0x920254
	public void ConfigureGeneric(bool isAdReady, string screen) { }

	// RVA: 0x9202FC Offset: 0x9202FC VA: 0x9202FC Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public abstract class RewardedAdEvent : AnalyticsDataEvent // TypeDefIndex: 11880
{
	// Methods

	// RVA: 0x9201D4 Offset: 0x9201D4 VA: 0x9201D4
	protected void .ctor(string name) { }

	// RVA: 0x92067C Offset: 0x92067C VA: 0x92067C
	private string AppendDailyPlacementData(string placement, int totalVideosWatched, int fixedPrizesCount) { }

	// RVA: 0x920738 Offset: 0x920738 VA: 0x920738
	private string AppendRevivePlacementData(string placement, int videoNumber) { }

	// RVA: 0x9207B0 Offset: 0x9207B0 VA: 0x9207B0
	public void ConfigureAsDefault(string placement) { }

	// RVA: 0x920814 Offset: 0x920814 VA: 0x920814
	public void ConfigureAsRevive(string placement) { }

	// RVA: 0x920A10 Offset: 0x920A10 VA: 0x920A10
	public void ConfigureAsDaily(string placement) { }
}

// Namespace: SYBO.Subway.Analytics
public class RewardedAdServedEvent : RewardedAdEvent // TypeDefIndex: 11881
{
	// Fields
	private const string Completed = "completed";

	// Methods

	// RVA: 0x920AEC Offset: 0x920AEC VA: 0x920AEC
	public void .ctor() { }

	// RVA: 0x920B44 Offset: 0x920B44 VA: 0x920B44
	public void ConfigureGeneric(bool completed, string screen) { }

	// RVA: 0x920BEC Offset: 0x920BEC VA: 0x920BEC Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class CalendarSharedEvent : SharedFeatureBaseEvent // TypeDefIndex: 11882
{
	// Fields
	private const string FeatureId = "dailyLogin";

	// Methods

	// RVA: 0xA4CA64 Offset: 0xA4CA64 VA: 0xA4CA64
	public static SharedFeatureBaseEvent AsClaim(CalendarInstanceData calendar, CalendarClaimMethod claimMethod, int tierIndex) { }

	// RVA: 0xA4CC44 Offset: 0xA4CC44 VA: 0xA4CC44
	public static SharedFeatureBaseEvent AsMegaRewardClaim(CalendarInstanceData calendar, CalendarClaimMethod claimMethod, int tierIndex) { }

	// RVA: 0xA4CC1C Offset: 0xA4CC1C VA: 0xA4CC1C
	private void .ctor(string name) { }

	// RVA: 0xA4CC24 Offset: 0xA4CC24 VA: 0xA4CC24
	private static SharedFeatureClaimType GetClaimType(CalendarClaimMethod claimMethod) { }

	// RVA: 0xA4CDF8 Offset: 0xA4CDF8 VA: 0xA4CDF8 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class ChallengesSharedEvent : SharedFeatureBaseEvent // TypeDefIndex: 11883
{
	// Methods

	// RVA: 0x8A95A0 Offset: 0x8A95A0 VA: 0x8A95A0
	public static SharedFeatureBaseEvent AsClaim(ChallengeInstanceData challenge, RewardTierData tier, int tierIndex, int runNumber) { }

	// RVA: 0x8A98B0 Offset: 0x8A98B0 VA: 0x8A98B0
	public static SharedFeatureBaseEvent AsUnlock(ChallengeInstanceData challenge, RewardTierData tier, int tierIndex, int runNumber) { }

	// RVA: 0x8A9AE4 Offset: 0x8A9AE4 VA: 0x8A9AE4
	public static SharedFeatureBaseEvent AsOptin(ChallengeInstanceData challenge) { }

	// RVA: 0x8A97E8 Offset: 0x8A97E8 VA: 0x8A97E8
	protected void .ctor(string name) { }

	// RVA: 0x8A97F0 Offset: 0x8A97F0 VA: 0x8A97F0
	protected static SharedFeatureClaimType GetClaimType(RewardTierData tier) { }

	// RVA: 0x8A986C Offset: 0x8A986C VA: 0x8A986C
	protected static SharedFeatureRequirementType GetRequirementType(ChallengeInstanceData challenge) { }

	// RVA: 0x8A9BFC Offset: 0x8A9BFC VA: 0x8A9BFC Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class EliteChallengesSharedEvent : ChallengesSharedEvent // TypeDefIndex: 11884
{
	// Methods

	// RVA: 0x619DF4 Offset: 0x619DF4 VA: 0x619DF4
	public static SharedFeatureBaseEvent AsClaim(ChallengeInstanceData challenge, RewardTierData tier, int tierIndex, int runNumber) { }

	// RVA: 0x61A040 Offset: 0x61A040 VA: 0x61A040
	public static SharedFeatureBaseEvent AsUnlock(ChallengeInstanceData challenge, RewardTierData tier, int runNumber) { }

	// RVA: 0x61A038 Offset: 0x61A038 VA: 0x61A038
	private void .ctor(string name) { }
}

// Namespace: SYBO.Subway.Analytics
public class MissionsSharedEvent : SharedFeatureBaseEvent // TypeDefIndex: 11885
{
	// Fields
	private const string FeatureId = "mission";

	// Methods

	// RVA: 0x9FBE3C Offset: 0x9FBE3C VA: 0x9FBE3C
	public static SharedFeatureBaseEvent AsClaim(MissionEntry mission, int setIndex, int tierCount, SharedFeaturePlacementType placement, int runNumber) { }

	// RVA: 0x9FC110 Offset: 0x9FC110 VA: 0x9FC110
	public static SharedFeatureBaseEvent AsUnlock(MissionEntry mission, int setIndex, int tierCount, int runNumber) { }

	// RVA: 0x9FC44C Offset: 0x9FC44C VA: 0x9FC44C Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }

	// RVA: 0x9FC108 Offset: 0x9FC108 VA: 0x9FC108
	private void .ctor(string name) { }
}

// Namespace: SYBO.Subway.Analytics
public class SeasonHuntSharedEvent : SharedFeatureBaseEvent // TypeDefIndex: 11886
{
	// Fields
	private const string SeasonHuntID = "seasonHunt";

	// Methods

	// RVA: 0xBB7F20 Offset: 0xBB7F20 VA: 0xBB7F20
	public static SharedFeatureBaseEvent AsClaim(SeasonHunt seasonHunt, int tierIndex, int runNumber) { }

	// RVA: 0xBB8124 Offset: 0xBB8124 VA: 0xBB8124
	public static SeasonHuntSharedEvent AsUnlock(SeasonHunt seasonHunt, int tierIndex, int runNumber, bool keyUnlocked) { }

	// RVA: 0xBB8114 Offset: 0xBB8114 VA: 0xBB8114
	private void .ctor(string name) { }

	// RVA: 0xBB811C Offset: 0xBB811C VA: 0xBB811C
	private static SharedFeatureClaimType GetClaimType() { }

	// RVA: 0xBB832C Offset: 0xBB832C VA: 0xBB832C
	private static string GetUnlockType(bool keyUnlocked) { }

	// RVA: 0xBB83EC Offset: 0xBB83EC VA: 0xBB83EC Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public enum IAPPurchaseDataEventStatus // TypeDefIndex: 11887
{
	// Fields
	public int value__; // 0x0
	public const IAPPurchaseDataEventStatus CannotValidate = 0;
	public const IAPPurchaseDataEventStatus TransactionValidated = 1;
	public const IAPPurchaseDataEventStatus TransactionNotValidated = 2;
	public const IAPPurchaseDataEventStatus TransactionCancelledByUser = 3;
	public const IAPPurchaseDataEventStatus TransactionCancelledBySystem = 4;
	public const IAPPurchaseDataEventStatus PurchaseAlreadyCompleted = 5;
	public const IAPPurchaseDataEventStatus PurchaseDeferred = 6;
	public const IAPPurchaseDataEventStatus PurchaseDeferredClaimed = 7;
	public const IAPPurchaseDataEventStatus SystemNotAvailable = 8;
}

// Namespace: SYBO.Subway.Analytics
public class IAPPurchaseDataEvent : AnalyticsDataEvent // TypeDefIndex: 11888
{
	// Fields
	private const string TransactionStatus = "transaction_status";
	private const string InternalErrorCode = "internal_error_code";
	private const string ScreensBefore = "screens_before";
	private const string Currency = "currency";
	private const string ValueLocal = "value_local";
	private const string ProductType = "product_type";
	private const string ProductId = "product_id";
	private const string TransactionID = "transaction_id";
	private const string SalesID = "sales_id";
	private const string SalesType = "sales_type";
	private const int ScreensBeforeWanted = 3;
	private IAPPurchaseDataEventStatus _status; // 0x10
	private ProductData _productData; // 0x14
	private Product _product; // 0x18
	private IAPPurchaseResult _purchaseResult; // 0x1C

	// Methods

	// RVA: 0xA2A898 Offset: 0xA2A898 VA: 0xA2A898
	public void .ctor() { }

	// RVA: 0xA2A930 Offset: 0xA2A930 VA: 0xA2A930
	public AnalyticsDataEvent AsValid(ProductData productData, IAPPurchaseResult purchaseResult) { }

	// RVA: 0xA2AAD8 Offset: 0xA2AAD8 VA: 0xA2AAD8
	public AnalyticsDataEvent AsSystemNotAvailable(IAPPurchaseResult purchaseResult) { }

	// RVA: 0xA2AB0C Offset: 0xA2AB0C VA: 0xA2AB0C
	public AnalyticsDataEvent AsFailure(ProductData productData, IAPPurchaseResult purchaseResult) { }

	// RVA: 0xA2ABD4 Offset: 0xA2ABD4 VA: 0xA2ABD4
	public AnalyticsDataEvent AsAlreadyCompleted(ProductData productData, IAPPurchaseResult purchaseResult) { }

	// RVA: 0xA2AC1C Offset: 0xA2AC1C VA: 0xA2AC1C
	public AnalyticsDataEvent AsNonPossibleToValidate(ProductData productData, IAPPurchaseResult purchaseResult) { }

	// RVA: 0xA2AC64 Offset: 0xA2AC64 VA: 0xA2AC64
	public AnalyticsDataEvent AsValidationFailed(ProductData productData, IAPPurchaseResult purchaseResult) { }

	// RVA: 0xA2ACAC Offset: 0xA2ACAC VA: 0xA2ACAC
	public AnalyticsDataEvent AsDeferredPurchase(ProductData productData, IAPPurchaseResult purchaseResult) { }

	// RVA: 0xA2ACF4 Offset: 0xA2ACF4 VA: 0xA2ACF4
	public AnalyticsDataEvent AsDeferredPurchaseClaimed(ProductData productData, IAPPurchaseResult purchaseResult) { }

	// RVA: 0xA2A978 Offset: 0xA2A978 VA: 0xA2A978
	private void SetupParameters() { }

	// RVA: 0xA2AD3C Offset: 0xA2AD3C VA: 0xA2AD3C
	private void AppendProductParameters() { }

	// RVA: 0xA2AE20 Offset: 0xA2AE20 VA: 0xA2AE20
	private void AppendProductDataParameters() { }

	// RVA: 0xA2B050 Offset: 0xA2B050 VA: 0xA2B050 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class MailReadEvent : AnalyticsDataEvent // TypeDefIndex: 11889
{
	// Fields
	private const string MailID = "mail_id";
	private const string Header = "header";
	private const string HasAttachment = "has_attachment";

	// Methods

	// RVA: 0x6E2084 Offset: 0x6E2084 VA: 0x6E2084
	public void .ctor() { }

	// RVA: 0x6E3AB8 Offset: 0x6E3AB8 VA: 0x6E3AB8
	public AnalyticsDataEvent Configure(string id, string header, bool hasAttachment) { }

	// RVA: 0x6E3B94 Offset: 0x6E3B94 VA: 0x6E3B94 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class AgeDefinedDataEvent : AnalyticsDataEvent // TypeDefIndex: 11890
{
	// Fields
	private const string Age = "age";

	// Methods

	// RVA: 0x6F2FD0 Offset: 0x6F2FD0 VA: 0x6F2FD0
	public void .ctor() { }

	// RVA: 0x6F30FC Offset: 0x6F30FC VA: 0x6F30FC
	public AgeDefinedDataEvent Configure(int age) { }

	// RVA: 0x6F328C Offset: 0x6F328C VA: 0x6F328C Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class NewProfileCreatedDataEvent : AnalyticsDataEvent // TypeDefIndex: 11891
{
	// Fields
	private const string UserID = "user_id";

	// Methods

	// RVA: 0x86B450 Offset: 0x86B450 VA: 0x86B450
	public void .ctor() { }

	// RVA: 0x86B4E8 Offset: 0x86B4E8 VA: 0x86B4E8
	public NewProfileCreatedDataEvent Configure(string id) { }

	// RVA: 0x86B55C Offset: 0x86B55C VA: 0x86B55C Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class SelectedMusicChangedDataEvent : AnalyticsDataEvent // TypeDefIndex: 11892
{
	// Fields
	private const string SelectedSongIdKey = "selected_song_id";

	// Methods

	// RVA: 0x5A9A84 Offset: 0x5A9A84 VA: 0x5A9A84
	public void .ctor() { }

	// RVA: 0x5A9B1C Offset: 0x5A9B1C VA: 0x5A9B1C
	public AnalyticsDataEvent Configure(string id) { }

	// RVA: 0x5A9B90 Offset: 0x5A9B90 VA: 0x5A9B90 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class TopRunClaimedEvent : AnalyticsDataEvent // TypeDefIndex: 11893
{
	// Fields
	private const string TopRunClaimed = "toprun_claimed";
	private const string WeekNumber = "week_no";
	private const string Country = "tournament_country";
	private const string Medal = "medal";
	private const string Rank = "rank";
	private const string Score = "score";
	private const string ScoreMultiplier = "score_multiplier";
	private const string Character = "character";
	private const string Board = "board";
	private const string ClaimType = "claim_type";

	// Methods

	// RVA: 0x719EBC Offset: 0x719EBC VA: 0x719EBC
	public void .ctor() { }

	// RVA: 0x719F54 Offset: 0x719F54 VA: 0x719F54
	public AnalyticsDataEvent Configure(TopRunResult result, TournamentMetaPlayer myPlayerData) { }

	// RVA: 0x71A37C Offset: 0x71A37C VA: 0x71A37C Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Subway.Analytics
public class CityTravelDataEvent : AnalyticsDataEvent // TypeDefIndex: 11894
{
	// Fields
	private const string City = "city";
	private const string PreviousCity = "previous_city";
	private const string LoadingTime = "loading_time_elapsed";
	private const string LoadState = "load_state";

	// Methods

	// RVA: 0x8CAB84 Offset: 0x8CAB84 VA: 0x8CAB84
	public void .ctor() { }

	// RVA: 0x8CAC1C Offset: 0x8CAC1C VA: 0x8CAC1C
	public AnalyticsDataEvent Configure(long loadingTimeMs, string current, string previous, bool loadSuccess) { }

	// RVA: 0x8CAD40 Offset: 0x8CAD40 VA: 0x8CAD40 Slot: 7
	public override AnalyticsDataEventValidator GetValidator() { }
}

// Namespace: SYBO.Common
public class AnimationClipPlayer : MonoBehaviour // TypeDefIndex: 11895
{
	// Fields
	[SerializeField] // RVA: 0x3AB770 Offset: 0x3AB770 VA: 0x3AB770
	private Animation _animation; // 0xC

	// Methods

	// RVA: 0x709040 Offset: 0x709040 VA: 0x709040
	public void PlayClip(string name) { }

	// RVA: 0x709070 Offset: 0x709070 VA: 0x709070
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class AnimationEventChannel : MonoBehaviour // TypeDefIndex: 11896
{
	// Fields
	public UnityEvent Event; // 0xC

	// Methods

	// RVA: 0x70AF58 Offset: 0x70AF58 VA: 0x70AF58
	public void Raise() { }

	// RVA: 0x70AF80 Offset: 0x70AF80 VA: 0x70AF80
	public void .ctor() { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F71C Offset: 0x36F71C VA: 0x36F71C
private sealed class AudioFader.<DoFade>d__5 : IEnumerator<object>, IEnumerator, IDisposable // TypeDefIndex: 11897
{
	// Fields
	private int <>1__state; // 0x8
	private object <>2__current; // 0xC
	public float targetVolume; // 0x10
	public AudioFader <>4__this; // 0x14
	public float duration; // 0x18
	private float <initialVolume>5__2; // 0x1C
	private float <t>5__3; // 0x20

	// Properties
	private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	[DebuggerHiddenAttribute] // RVA: 0x3BD6A0 Offset: 0x3BD6A0 VA: 0x3BD6A0
	// RVA: 0x892B90 Offset: 0x892B90 VA: 0x892B90
	public void .ctor(int <>1__state) { }

	[DebuggerHiddenAttribute] // RVA: 0x3BD6B0 Offset: 0x3BD6B0 VA: 0x3BD6B0
	// RVA: 0x892BB0 Offset: 0x892BB0 VA: 0x892BB0 Slot: 5
	private void System.IDisposable.Dispose() { }

	// RVA: 0x892BB4 Offset: 0x892BB4 VA: 0x892BB4 Slot: 6
	private bool MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BD6C0 Offset: 0x3BD6C0 VA: 0x3BD6C0
	// RVA: 0x892E00 Offset: 0x892E00 VA: 0x892E00 Slot: 4
	private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BD6D0 Offset: 0x3BD6D0 VA: 0x3BD6D0
	// RVA: 0x892E08 Offset: 0x892E08 VA: 0x892E08 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BD6E0 Offset: 0x3BD6E0 VA: 0x3BD6E0
	// RVA: 0x892E50 Offset: 0x892E50 VA: 0x892E50 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
}

// Namespace: SYBO.Common
public class AudioFader : MonoBehaviour // TypeDefIndex: 11898
{
	// Fields
	[SerializeField] // RVA: 0x3AB780 Offset: 0x3AB780 VA: 0x3AB780
	private AudioSource _source; // 0xC
	[SerializeField] // RVA: 0x3AB790 Offset: 0x3AB790 VA: 0x3AB790
	private float _minValue; // 0x10
	[SerializeField] // RVA: 0x3AB7A0 Offset: 0x3AB7A0 VA: 0x3AB7A0
	private float _maxValue; // 0x14

	// Methods

	// RVA: 0x69B848 Offset: 0x69B848 VA: 0x69B848
	public void FadeIn(float duration) { }

	// RVA: 0x69B924 Offset: 0x69B924 VA: 0x69B924
	public void FadeOut(float duration) { }

	[IteratorStateMachineAttribute] // RVA: 0x3BD634 Offset: 0x3BD634 VA: 0x3BD634
	// RVA: 0x69B870 Offset: 0x69B870 VA: 0x69B870
	private IEnumerator DoFade(float duration, float targetVolume) { }

	// RVA: 0x69B94C Offset: 0x69B94C VA: 0x69B94C
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class CacheBehavior : MonoBehaviour // TypeDefIndex: 11899
{
	// Fields
	private Type _cachedType; // 0xC
	[HideInInspector] // RVA: 0x3AB7B0 Offset: 0x3AB7B0 VA: 0x3AB7B0
	private Collider _collider; // 0x10
	[HideInInspector] // RVA: 0x3AB7C0 Offset: 0x3AB7C0 VA: 0x3AB7C0
	private bool _hasCollider; // 0x14
	[HideInInspector] // RVA: 0x3AB7D0 Offset: 0x3AB7D0 VA: 0x3AB7D0
	private Renderer _renderer; // 0x18
	[HideInInspector] // RVA: 0x3AB7E0 Offset: 0x3AB7E0 VA: 0x3AB7E0
	private bool _hasRenderer; // 0x1C
	[HideInInspector] // RVA: 0x3AB7F0 Offset: 0x3AB7F0 VA: 0x3AB7F0
	private Rigidbody _rigidbody; // 0x20
	[HideInInspector] // RVA: 0x3AB800 Offset: 0x3AB800 VA: 0x3AB800
	private bool _hasRigidbody; // 0x24
	[HideInInspector] // RVA: 0x3AB810 Offset: 0x3AB810 VA: 0x3AB810
	private Rigidbody2D _rigidbody2D; // 0x28
	[HideInInspector] // RVA: 0x3AB820 Offset: 0x3AB820 VA: 0x3AB820
	private bool _hasRigidBody2D; // 0x2C
	[HideInInspector] // RVA: 0x3AB830 Offset: 0x3AB830 VA: 0x3AB830
	private Transform _transform; // 0x30
	[HideInInspector] // RVA: 0x3AB840 Offset: 0x3AB840 VA: 0x3AB840
	private bool _hasTransform; // 0x34
	[HideInInspector] // RVA: 0x3AB850 Offset: 0x3AB850 VA: 0x3AB850
	private GameObject _gameObject; // 0x38
	[HideInInspector] // RVA: 0x3AB860 Offset: 0x3AB860 VA: 0x3AB860
	private bool _hasGameObject; // 0x3C
	[HideInInspector] // RVA: 0x3AB870 Offset: 0x3AB870 VA: 0x3AB870
	private RectTransform _rectTransform; // 0x40
	[HideInInspector] // RVA: 0x3AB880 Offset: 0x3AB880 VA: 0x3AB880
	private bool _hasRectTransform; // 0x44

	// Properties
	public Collider collider { get; }
	public Renderer renderer { get; }
	public Rigidbody rigidbody { get; }
	public Rigidbody2D rigidbody2D { get; }
	public Transform transform { get; }
	public GameObject gameObject { get; }
	public RectTransform rectTransform { get; }

	// Methods

	// RVA: 0x6CC47C Offset: 0x6CC47C VA: 0x6CC47C
	public Type GetCachedType() { }

	// RVA: 0x6CC51C Offset: 0x6CC51C VA: 0x6CC51C
	public Collider get_collider() { }

	// RVA: 0x6CC5E8 Offset: 0x6CC5E8 VA: 0x6CC5E8
	public Renderer get_renderer() { }

	// RVA: 0x6CC6B4 Offset: 0x6CC6B4 VA: 0x6CC6B4
	public Rigidbody get_rigidbody() { }

	// RVA: 0x6CC778 Offset: 0x6CC778 VA: 0x6CC778
	public Rigidbody2D get_rigidbody2D() { }

	// RVA: 0x6B2EC0 Offset: 0x6B2EC0 VA: 0x6B2EC0
	public Transform get_transform() { }

	// RVA: 0x6B12E8 Offset: 0x6B12E8 VA: 0x6B12E8
	public GameObject get_gameObject() { }

	// RVA: 0x6CC844 Offset: 0x6CC844 VA: 0x6CC844
	public RectTransform get_rectTransform() { }

	// RVA: 0x6CC92C Offset: 0x6CC92C VA: 0x6CC92C
	public void .ctor() { }
}

// Namespace: SYBO.Common
public static class CameraUtils // TypeDefIndex: 11900
{
	// Methods

	// RVA: 0xA51F4C Offset: 0xA51F4C VA: 0xA51F4C
	public static Vector3 ConvertPositionBetweenCameraSpaces(Camera sourceCamera, Camera targetCamera, Vector3 worldPosition) { }

	// RVA: 0xA52000 Offset: 0xA52000 VA: 0xA52000
	public static Vector3 ConvertPositionBetweenCameraSpaces(Camera sourceCamera, Camera targetCamera, Vector3 worldPosition, float distance) { }
}

// Namespace: SYBO.Common
public static class ColorHelper // TypeDefIndex: 11901
{
	// Methods

	// RVA: 0x61EBB0 Offset: 0x61EBB0 VA: 0x61EBB0
	public static Color ParseHTMLColor(string htmlColor) { }

	// RVA: 0x61EC1C Offset: 0x61EC1C VA: 0x61EC1C
	public static Color ParseHTMLColor(string htmlColor, Color fallbackColor) { }

	// RVA: 0x61EC84 Offset: 0x61EC84 VA: 0x61EC84
	public static string ConvertToHTMLColor(Color color) { }
}

// Namespace: SYBO.Common
public class CustomList<T> : List<T> // TypeDefIndex: 11902
{
	// Fields
	private static readonly IReadOnlyList<T> CachedEmpty; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public static IReadOnlyList<T> Empty() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xED00CC Offset: 0xED00CC VA: 0xED00CC
	|-CustomList<EventScoreMultiplier>.Empty
	|-CustomList<object>.Empty
	|-CustomList<SubwayEntity>.Empty
	*/

	// RVA: -1 Offset: -1
	public void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xED01D4 Offset: 0xED01D4 VA: 0xED01D4
	|-CustomList<object>..ctor
	*/

	// RVA: -1 Offset: -1
	private static void .cctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xED028C Offset: 0xED028C VA: 0xED028C
	|-CustomList<object>..cctor
	*/
}

// Namespace: SYBO.Common
[ExtensionAttribute] // RVA: 0x36F72C Offset: 0x36F72C VA: 0x36F72C
public static class DateTimeExtensions // TypeDefIndex: 11903
{
	// Methods

	[ExtensionAttribute] // RVA: 0x3BD6F0 Offset: 0x3BD6F0 VA: 0x3BD6F0
	// RVA: 0x6024CC Offset: 0x6024CC VA: 0x6024CC
	public static DateTime ToGameDataLocal(DateTime dateTime) { }

	[ExtensionAttribute] // RVA: 0x3BD700 Offset: 0x3BD700 VA: 0x3BD700
	// RVA: 0x602504 Offset: 0x602504 VA: 0x602504
	public static DateTime ToLocalToday(DateTime dateTime) { }

	[ExtensionAttribute] // RVA: 0x3BD710 Offset: 0x3BD710 VA: 0x3BD710
	// RVA: 0x60267C Offset: 0x60267C VA: 0x60267C
	public static DateTime ToLocalDate(DateTime dateTime, DateTime date) { }

	[ExtensionAttribute] // RVA: 0x3BD720 Offset: 0x3BD720 VA: 0x3BD720
	// RVA: 0x602810 Offset: 0x602810 VA: 0x602810
	public static DateTime GetNextWeekday(DateTime dateTime, DayOfWeek day) { }

	[ExtensionAttribute] // RVA: 0x3BD730 Offset: 0x3BD730 VA: 0x3BD730
	// RVA: 0x602894 Offset: 0x602894 VA: 0x602894
	public static int GetIso8601WeekOfYear(DateTime dateTime) { }

	[ExtensionAttribute] // RVA: 0x3BD740 Offset: 0x3BD740 VA: 0x3BD740
	// RVA: 0x602A3C Offset: 0x602A3C VA: 0x602A3C
	public static DateTime RoundUp(DateTime dateTime, TimeSpan timeSpan) { }

	[ExtensionAttribute] // RVA: 0x3BD750 Offset: 0x3BD750 VA: 0x3BD750
	// RVA: 0x602AC8 Offset: 0x602AC8 VA: 0x602AC8
	public static int GetYears(TimeSpan timeSpan) { }
}

// Namespace: SYBO.Common
public class DateTimeRfc3339Serializer : JsonCustomSerializer // TypeDefIndex: 11904
{
	// Methods

	// RVA: 0x602B88 Offset: 0x602B88 VA: 0x602B88 Slot: 4
	public override object Deserialize(JsonDict json, JsonContext context) { }

	// RVA: 0x603428 Offset: 0x603428 VA: 0x603428 Slot: 5
	public override JsonDict Serialize(object obj, JsonContext context) { }

	// RVA: 0x603A30 Offset: 0x603A30 VA: 0x603A30
	public void .ctor() { }
}

// Namespace: 
public sealed class DebugUtils.LineDrawFunc : MulticastDelegate // TypeDefIndex: 11905
{
	// Methods

	// RVA: 0x76D150 Offset: 0x76D150 VA: 0x76D150
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x76D164 Offset: 0x76D164 VA: 0x76D164 Slot: 13
	public virtual void Invoke(Vector3 a, Vector3 b) { }

	// RVA: 0x76D4E0 Offset: 0x76D4E0 VA: 0x76D4E0 Slot: 14
	public virtual IAsyncResult BeginInvoke(Vector3 a, Vector3 b, AsyncCallback callback, object object) { }

	// RVA: 0x76D59C Offset: 0x76D59C VA: 0x76D59C Slot: 15
	public virtual void EndInvoke(IAsyncResult result) { }
}

// Namespace: SYBO.Common
public class DebugUtils // TypeDefIndex: 11906
{
	// Methods

	// RVA: 0x608C90 Offset: 0x608C90 VA: 0x608C90
	public static string FormattedTransformHierarchyString(Transform t) { }

	// RVA: 0x608F18 Offset: 0x608F18 VA: 0x608F18
	public static void DrawFunction(Func<float, Vector3> f, float tmin, float tmax, int segments, DebugUtils.LineDrawFunc drawFunc) { }

	// RVA: 0x6090A8 Offset: 0x6090A8 VA: 0x6090A8
	public void .ctor() { }
}

// Namespace: SYBO.Common
[AttributeUsageAttribute] // RVA: 0x36F73C Offset: 0x36F73C VA: 0x36F73C
public class EasyScriptableObject : Attribute // TypeDefIndex: 11907
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x3AB890 Offset: 0x3AB890 VA: 0x3AB890
	private string <DisplayName>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x3AB8A0 Offset: 0x3AB8A0 VA: 0x3AB8A0
	private string <FileName>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x3AB8B0 Offset: 0x3AB8B0 VA: 0x3AB8B0
	private int <Priority>k__BackingField; // 0x10

	// Properties
	public string DisplayName { get; set; }
	public string FileName { get; set; }
	public int Priority { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x3BD760 Offset: 0x3BD760 VA: 0x3BD760
	// RVA: 0x6166DC Offset: 0x6166DC VA: 0x6166DC
	public string get_DisplayName() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BD770 Offset: 0x3BD770 VA: 0x3BD770
	// RVA: 0x6166E4 Offset: 0x6166E4 VA: 0x6166E4
	public void set_DisplayName(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x3BD780 Offset: 0x3BD780 VA: 0x3BD780
	// RVA: 0x6166EC Offset: 0x6166EC VA: 0x6166EC
	public string get_FileName() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BD790 Offset: 0x3BD790 VA: 0x3BD790
	// RVA: 0x6166F4 Offset: 0x6166F4 VA: 0x6166F4
	public void set_FileName(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x3BD7A0 Offset: 0x3BD7A0 VA: 0x3BD7A0
	// RVA: 0x6166FC Offset: 0x6166FC VA: 0x6166FC
	public int get_Priority() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BD7B0 Offset: 0x3BD7B0 VA: 0x3BD7B0
	// RVA: 0x616704 Offset: 0x616704 VA: 0x616704
	public void set_Priority(int value) { }

	// RVA: 0x61670C Offset: 0x61670C VA: 0x61670C
	public void .ctor() { }

	// RVA: 0x616714 Offset: 0x616714 VA: 0x616714
	public void .ctor(string displayName) { }
}

// Namespace: SYBO.Common
public class EmbedEditorAttribute : PropertyAttribute // TypeDefIndex: 11908
{
	// Methods

	// RVA: 0x61A21C Offset: 0x61A21C VA: 0x61A21C
	public void .ctor() { }
}

// Namespace: SYBO.Common
[Serializable]
public struct BoolReference // TypeDefIndex: 11909
{
	// Fields
	public bool Constant; // 0x0
	public BoolVariableId VariableId; // 0x4
	private bool _initialized; // 0x8
	private GlobalBool _variable; // 0xC

	// Properties
	public bool Value { get; set; }

	// Methods

	// RVA: 0x6BE1B4 Offset: 0x6BE1B4 VA: 0x6BE1B4
	public bool get_Value() { }

	// RVA: 0x6BE2BC Offset: 0x6BE2BC VA: 0x6BE2BC
	public void set_Value(bool value) { }

	// RVA: 0x6BE20C Offset: 0x6BE20C VA: 0x6BE20C
	private void TryInit() { }

	// RVA: 0x6BE334 Offset: 0x6BE334 VA: 0x6BE334
	public static bool op_Implicit(BoolReference i) { }
}

// Namespace: SYBO.Common
public abstract class EventVariable : ScriptableObject // TypeDefIndex: 11910
{
	// Fields
	protected const string AssetMenu = "Common/Variable/";

	// Methods

	// RVA: 0x9639BC Offset: 0x9639BC VA: 0x9639BC
	protected void Awake() { }

	// RVA: 0x9639C8 Offset: 0x9639C8 VA: 0x9639C8
	protected void .ctor() { }
}

// Namespace: 
[Serializable]
public class EventVariable.OnChangedEvent<T> : UnityEvent<T> // TypeDefIndex: 11911
{
	// Methods

	// RVA: -1 Offset: -1
	public void .ctor() { }
}

// Namespace: SYBO.Common
public abstract class EventVariable<T> : EventVariable // TypeDefIndex: 11912
{
	// Fields
	protected T _value; // 0x0
	public EventVariable.OnChangedEvent<T> OnChanged; // 0x0
	[CompilerGeneratedAttribute] // RVA: 0x3AB8C0 Offset: 0x3AB8C0 VA: 0x3AB8C0
	private int <Delta>k__BackingField; // 0x0

	// Properties
	public int Delta { get; set; }
	public T Value { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x3BD7C0 Offset: 0x3BD7C0 VA: 0x3BD7C0
	// RVA: -1 Offset: -1
	public int get_Delta() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BD7D0 Offset: 0x3BD7D0 VA: 0x3BD7D0
	// RVA: -1 Offset: -1
	private void set_Delta(int value) { }

	// RVA: -1 Offset: -1
	public T get_Value() { }

	// RVA: -1 Offset: -1
	public void set_Value(T value) { }

	// RVA: -1 Offset: -1
	public static T op_Implicit(EventVariable<T> i) { }

	// RVA: -1 Offset: -1
	protected void .ctor() { }
}

// Namespace: SYBO.Common
[CreateAssetMenuAttribute] // RVA: 0x36F768 Offset: 0x36F768 VA: 0x36F768
public class GameObjectRuntimeSet : RuntimeSet<GameObject> // TypeDefIndex: 11913
{
	// Methods

	// RVA: 0x588BC8 Offset: 0x588BC8 VA: 0x588BC8
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class GameObjectRuntimeSetElement : MonoBehaviour // TypeDefIndex: 11914
{
	// Fields
	[SerializeField] // RVA: 0x3AB8D0 Offset: 0x3AB8D0 VA: 0x3AB8D0
	private GameObjectRuntimeSet _runtimeSet; // 0xC

	// Methods

	// RVA: 0x588C20 Offset: 0x588C20 VA: 0x588C20
	private void OnEnable() { }

	// RVA: 0x588CF4 Offset: 0x588CF4 VA: 0x588CF4
	private void OnDisable() { }

	// RVA: 0x588DC8 Offset: 0x588DC8 VA: 0x588DC8
	public void .ctor() { }
}

// Namespace: SYBO.Common
[Serializable]
public struct IntReference // TypeDefIndex: 11915
{
	// Fields
	public int Constant; // 0x0
	public IntVariableId VariableId; // 0x4
	private bool _initialized; // 0x8
	private GlobalInt _variable; // 0xC

	// Properties
	public int Value { get; set; }

	// Methods

	// RVA: 0xA3B3D8 Offset: 0xA3B3D8 VA: 0xA3B3D8
	public int get_Value() { }

	// RVA: 0xA3B4E0 Offset: 0xA3B4E0 VA: 0xA3B4E0
	public void set_Value(int value) { }

	// RVA: 0xA3B430 Offset: 0xA3B430 VA: 0xA3B430
	private void TryInit() { }

	// RVA: 0xA3B558 Offset: 0xA3B558 VA: 0xA3B558
	public static int op_Implicit(IntReference i) { }
}

// Namespace: SYBO.Common
public abstract class RuntimeSet<T> : ScriptableObject // TypeDefIndex: 11916
{
	// Fields
	private List<T> _elements; // 0x0

	// Properties
	public int Count { get; }
	public IEnumerable<T> Elements { get; }

	// Methods

	// RVA: -1 Offset: -1
	public int get_Count() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFBD12C Offset: 0xFBD12C VA: 0xFBD12C
	|-RuntimeSet<object>.get_Count
	*/

	// RVA: -1 Offset: -1
	public IEnumerable<T> get_Elements() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFBD164 Offset: 0xFBD164 VA: 0xFBD164
	|-RuntimeSet<object>.get_Elements
	*/

	// RVA: -1 Offset: -1
	public void Add(T element) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFBD16C Offset: 0xFBD16C VA: 0xFBD16C
	|-RuntimeSet<GameObject>.Add
	|-RuntimeSet<object>.Add
	*/

	// RVA: -1 Offset: -1
	public void Remove(T element) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFBD1E8 Offset: 0xFBD1E8 VA: 0xFBD1E8
	|-RuntimeSet<GameObject>.Remove
	|-RuntimeSet<object>.Remove
	*/

	// RVA: -1 Offset: -1
	protected void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFBD228 Offset: 0xFBD228 VA: 0xFBD228
	|-RuntimeSet<GameObject>..ctor
	|-RuntimeSet<object>..ctor
	*/
}

// Namespace: 
public enum InspectorHelpBoxAttribute.MessageTypes // TypeDefIndex: 11917
{
	// Fields
	public int value__; // 0x0
	public const InspectorHelpBoxAttribute.MessageTypes None = 0;
	public const InspectorHelpBoxAttribute.MessageTypes Info = 1;
	public const InspectorHelpBoxAttribute.MessageTypes Warning = 2;
	public const InspectorHelpBoxAttribute.MessageTypes Error = 3;
}

// Namespace: SYBO.Common
public class InspectorHelpBoxAttribute : PropertyAttribute // TypeDefIndex: 11918
{
	// Fields
	public string Text; // 0xC
	public InspectorHelpBoxAttribute.MessageTypes MessageType; // 0x10

	// Methods

	// RVA: 0xA3AFF0 Offset: 0xA3AFF0 VA: 0xA3AFF0
	public void .ctor(string text, InspectorHelpBoxAttribute.MessageTypes messageType = 0) { }
}

// Namespace: SYBO.Common
[AttributeUsageAttribute] // RVA: 0x36F79C Offset: 0x36F79C VA: 0x36F79C
public class IgnoreIfDefaultAttribute : JsonFieldInfoModifierAttribute // TypeDefIndex: 11919
{
	// Methods

	// RVA: 0xA3016C Offset: 0xA3016C VA: 0xA3016C Slot: 7
	public override void ModifyFieldInfo(JsonFieldInfo fieldInfo) { }

	// RVA: 0xA30190 Offset: 0xA30190 VA: 0xA30190
	public void .ctor() { }
}

// Namespace: SYBO.Common
[ExtensionAttribute] // RVA: 0x36F7B0 Offset: 0x36F7B0 VA: 0x36F7B0
public static class JsonSchemaExtensions // TypeDefIndex: 11920
{
	// Fields
	public const string AllOfKey = "allOf";
	public const string OneOfKey = "oneOf";
	public const string AnyOfKey = "anyOf";
	public const string NotKey = "not";
	public const string ConstKey = "const";
	public const string IfKey = "if";
	public const string ThenKey = "then";

	// Methods

	[ExtensionAttribute] // RVA: 0x3BD7E0 Offset: 0x3BD7E0 VA: 0x3BD7E0
	// RVA: 0x97D55C Offset: 0x97D55C VA: 0x97D55C
	public static JsonSchema SetConstValue(JsonSchema jsonSchema, object value) { }

	[ExtensionAttribute] // RVA: 0x3BD7F0 Offset: 0x3BD7F0 VA: 0x3BD7F0
	// RVA: 0x97D5EC Offset: 0x97D5EC VA: 0x97D5EC
	public static void If(JsonSchema jsonSchema, string propertyName, JsonSchema propertySchema) { }

	[ExtensionAttribute] // RVA: 0x3BD800 Offset: 0x3BD800 VA: 0x3BD800
	// RVA: 0x97D7AC Offset: 0x97D7AC VA: 0x97D7AC
	public static JsonSchema Not(JsonSchema jsonSchema, JsonSchema negatedSchema) { }

	[ExtensionAttribute] // RVA: 0x3BD810 Offset: 0x3BD810 VA: 0x3BD810
	// RVA: 0x97D83C Offset: 0x97D83C VA: 0x97D83C
	public static void Then(JsonSchema jsonSchema, string propertyName, JsonSchema propertySchema) { }

	[ExtensionAttribute] // RVA: 0x3BD820 Offset: 0x3BD820 VA: 0x3BD820
	// RVA: 0x97D8BC Offset: 0x97D8BC VA: 0x97D8BC
	public static void Then(JsonSchema jsonSchema, JsonSchema thenSchema) { }

	[ExtensionAttribute] // RVA: 0x3BD830 Offset: 0x3BD830 VA: 0x3BD830
	// RVA: 0x97D948 Offset: 0x97D948 VA: 0x97D948
	public static void AddAllOf(JsonSchema jsonSchema, JsonSchema[] conditions) { }

	[ExtensionAttribute] // RVA: 0x3BD840 Offset: 0x3BD840 VA: 0x3BD840
	// RVA: 0x97DA4C Offset: 0x97DA4C VA: 0x97DA4C
	public static void AddOneOf(JsonSchema jsonSchema, JsonSchema[] conditions) { }

	[ExtensionAttribute] // RVA: 0x3BD850 Offset: 0x3BD850 VA: 0x3BD850
	// RVA: 0x97DA58 Offset: 0x97DA58 VA: 0x97DA58
	public static void AddAnyOf(JsonSchema jsonSchema, JsonSchema[] conditions) { }

	[ExtensionAttribute] // RVA: 0x3BD860 Offset: 0x3BD860 VA: 0x3BD860
	// RVA: 0x97D954 Offset: 0x97D954 VA: 0x97D954
	public static void AddSchemaCombination(JsonSchema jsonSchema, JsonSchemaCombinationMethod method, JsonSchema[] conditions) { }

	[ExtensionAttribute] // RVA: 0x3BD870 Offset: 0x3BD870 VA: 0x3BD870
	// RVA: 0x97DA64 Offset: 0x97DA64 VA: 0x97DA64
	public static void AddSchemaCombination(JsonSchema jsonSchema, JsonSchemaCombinationMethod method, JsonList conditionList) { }

	// RVA: 0x97DB00 Offset: 0x97DB00 VA: 0x97DB00
	private static string GetCombinationMethodKey(JsonSchemaCombinationMethod method) { }

	[ExtensionAttribute] // RVA: 0x3BD880 Offset: 0x3BD880 VA: 0x3BD880
	// RVA: 0x97D66C Offset: 0x97D66C VA: 0x97D66C
	public static JsonSchema GetOrCreateSchema(JsonSchema jsonSchema, string name) { }

	[ExtensionAttribute] // RVA: 0x3BD890 Offset: 0x3BD890 VA: 0x3BD890
	// RVA: 0x97DBAC Offset: 0x97DBAC VA: 0x97DBAC
	public static JsonSchema GetPropertyNamesSchema(JsonSchema schema) { }
}

// Namespace: SYBO.Common
public enum JsonSchemaCombinationMethod // TypeDefIndex: 11921
{
	// Fields
	public int value__; // 0x0
	public const JsonSchemaCombinationMethod AllOf = 0;
	public const JsonSchemaCombinationMethod OneOf = 1;
	public const JsonSchemaCombinationMethod AnyOf = 2;
}

// Namespace: SYBO.Common
public class ReferenceableAsAttribute : JsonPropertyValidationAttribute // TypeDefIndex: 11922
{
	// Fields
	private Type _referencedType; // 0x8

	// Methods

	// RVA: 0x90B5D8 Offset: 0x90B5D8 VA: 0x90B5D8
	public void .ctor(Type referencedType) { }

	// RVA: 0x90B5F8 Offset: 0x90B5F8 VA: 0x90B5F8 Slot: 7
	public override void AddConstraint(JsonSchema objectSchema, JsonFieldInfo fieldInfo) { }
}

// Namespace: SYBO.Common
public class ReferenceableDictionaryAttribute : JsonPropertyValidationAttribute // TypeDefIndex: 11923
{
	// Methods

	// RVA: 0x90B660 Offset: 0x90B660 VA: 0x90B660 Slot: 7
	public override void AddConstraint(JsonSchema objectSchema, JsonFieldInfo fieldInfo) { }

	// RVA: 0x90B6CC Offset: 0x90B6CC VA: 0x90B6CC
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class RequiredIfAttribute : JsonPropertyValidationAttribute // TypeDefIndex: 11924
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x3AB8E0 Offset: 0x3AB8E0 VA: 0x3AB8E0
	private string <ConditionFieldPath>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x3AB8F0 Offset: 0x3AB8F0 VA: 0x3AB8F0
	private object <ReferenceValue>k__BackingField; // 0xC

	// Properties
	public string ConditionFieldPath { get; set; }
	public object ReferenceValue { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x3BD8A0 Offset: 0x3BD8A0 VA: 0x3BD8A0
	// RVA: 0x90F400 Offset: 0x90F400 VA: 0x90F400
	public string get_ConditionFieldPath() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BD8B0 Offset: 0x3BD8B0 VA: 0x3BD8B0
	// RVA: 0x90F408 Offset: 0x90F408 VA: 0x90F408
	public void set_ConditionFieldPath(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x3BD8C0 Offset: 0x3BD8C0 VA: 0x3BD8C0
	// RVA: 0x90F410 Offset: 0x90F410 VA: 0x90F410
	public object get_ReferenceValue() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BD8D0 Offset: 0x3BD8D0 VA: 0x3BD8D0
	// RVA: 0x90F418 Offset: 0x90F418 VA: 0x90F418
	public void set_ReferenceValue(object value) { }

	// RVA: 0x90F420 Offset: 0x90F420 VA: 0x90F420
	public void .ctor(string conditionfieldPath) { }

	// RVA: 0x90F4A4 Offset: 0x90F4A4 VA: 0x90F4A4
	public void .ctor(string conditionFieldPath, object value) { }

	// RVA: 0x90F4CC Offset: 0x90F4CC VA: 0x90F4CC Slot: 7
	public override void AddConstraint(JsonSchema objectSchema, JsonFieldInfo fieldInfo) { }

	// RVA: 0x90F85C Offset: 0x90F85C VA: 0x90F85C
	private string GetConditionSerializedName(JsonFieldInfo fieldInfo) { }

	// RVA: 0x90F660 Offset: 0x90F660 VA: 0x90F660
	private void SetConditionValue(JsonFieldInfo fieldInfo, JsonSchema isValue) { }
}

// Namespace: SYBO.Common
public class TypedKeyReferenceAttribute : JsonPropertyValidationAttribute // TypeDefIndex: 11925
{
	// Fields
	private Type _referencedType; // 0x8
	private bool _referenceByKey; // 0xC

	// Methods

	// RVA: 0x72DED0 Offset: 0x72DED0 VA: 0x72DED0
	public void .ctor(Type type, bool referenceByKey = False) { }

	// RVA: 0x72DEF8 Offset: 0x72DEF8 VA: 0x72DEF8 Slot: 7
	public override void AddConstraint(JsonSchema objectSchema, JsonFieldInfo fieldInfo) { }
}

// Namespace: SYBO.Common
public abstract class KeyScriptableObject : ScriptableObjectWithName // TypeDefIndex: 11926
{
	// Methods

	// RVA: 0x97F8D4 Offset: 0x97F8D4 VA: 0x97F8D4
	protected void .ctor() { }
}

// Namespace: SYBO.Common
[ExtensionAttribute] // RVA: 0x36F7C0 Offset: 0x36F7C0 VA: 0x36F7C0
public static class LayerExtensions // TypeDefIndex: 11927
{
	// Methods

	[ExtensionAttribute] // RVA: 0x3BD8E0 Offset: 0x3BD8E0 VA: 0x3BD8E0
	// RVA: 0x98CB94 Offset: 0x98CB94 VA: 0x98CB94
	public static void SetLayerRecursively(GameObject go, int layer) { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F7D0 Offset: 0x36F7D0 VA: 0x36F7D0
[Serializable]
private sealed class MainCameraController.<>c // TypeDefIndex: 11928
{
	// Fields
	public static readonly MainCameraController.<>c <>9; // 0x0
	public static DOGetter<Vector3> <>9__5_0; // 0x4

	// Methods

	// RVA: 0x7806EC Offset: 0x7806EC VA: 0x7806EC
	private static void .cctor() { }

	// RVA: 0x780754 Offset: 0x780754 VA: 0x780754
	public void .ctor() { }

	// RVA: 0x78075C Offset: 0x78075C VA: 0x78075C
	internal Vector3 <Shake>b__5_0() { }
}

// Namespace: SYBO.Common
public class MainCameraController : MonoBehaviour // TypeDefIndex: 11929
{
	// Fields
	[SerializeField] // RVA: 0x3AB900 Offset: 0x3AB900 VA: 0x3AB900
	private float _shakeStrength; // 0xC
	[SerializeField] // RVA: 0x3AB910 Offset: 0x3AB910 VA: 0x3AB910
	private float _shakeDuration; // 0x10
	private Vector3 _shake; // 0x14
	public Transform CurrentTransformTarget; // 0x20

	// Methods

	// RVA: 0x6E92BC Offset: 0x6E92BC VA: 0x6E92BC
	private void LateUpdate() { }

	// RVA: 0x6E943C Offset: 0x6E943C VA: 0x6E943C
	public void Shake() { }

	// RVA: 0x6E9668 Offset: 0x6E9668 VA: 0x6E9668
	public void .ctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BD8F0 Offset: 0x3BD8F0 VA: 0x3BD8F0
	// RVA: 0x6E9684 Offset: 0x6E9684 VA: 0x6E9684
	private void <Shake>b__5_1(Vector3 shake) { }
}

// Namespace: SYBO.Common
public class MeshCombineGroup : MonoBehaviour // TypeDefIndex: 11930
{
	// Fields
	[SerializeField] // RVA: 0x3AB920 Offset: 0x3AB920 VA: 0x3AB920
	private Material _material; // 0xC
	[HeaderAttribute] // RVA: 0x3AB930 Offset: 0x3AB930 VA: 0x3AB930
	[SerializeField] // RVA: 0x3AB930 Offset: 0x3AB930 VA: 0x3AB930
	private MeshFilter _filter; // 0x10
	[SerializeField] // RVA: 0x3AB978 Offset: 0x3AB978 VA: 0x3AB978
	private MeshRenderer _renderer; // 0x14
	[SerializeField] // RVA: 0x3AB988 Offset: 0x3AB988 VA: 0x3AB988
	private MeshRenderer[] _renderers; // 0x18
	private Mesh _mesh; // 0x1C

	// Methods

	// RVA: 0x796B14 Offset: 0x796B14 VA: 0x796B14
	private void Start() { }

	// RVA: 0x7973E0 Offset: 0x7973E0 VA: 0x7973E0
	private void OnDestroy() { }

	// RVA: 0x797498 Offset: 0x797498 VA: 0x797498
	public void .ctor() { }
}

// Namespace: SYBO.Common
[CreateAssetMenuAttribute] // RVA: 0x36F7E0 Offset: 0x36F7E0 VA: 0x36F7E0
public class ModelAttachPointType : KeyScriptableObject // TypeDefIndex: 11931
{
	// Methods

	// RVA: 0x9FDA9C Offset: 0x9FDA9C VA: 0x9FDA9C
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class ModelAttachPoints : MonoBehaviour // TypeDefIndex: 11932
{
	// Fields
	[SerializeField] // RVA: 0x3AB998 Offset: 0x3AB998 VA: 0x3AB998
	private ModelAttachPoint[] _attachPoints; // 0xC

	// Methods

	// RVA: 0x9FDAA4 Offset: 0x9FDAA4 VA: 0x9FDAA4
	public Transform GetAttachPoint(ModelAttachPointType attachPointType) { }

	// RVA: 0x9FDC50 Offset: 0x9FDC50 VA: 0x9FDC50
	public List<Transform> GetAttachPoints(ModelAttachPointType attachPointType) { }

	// RVA: 0x9FDEAC Offset: 0x9FDEAC VA: 0x9FDEAC
	public void .ctor() { }
}

// Namespace: SYBO.Common
[Serializable]
internal class ModelAttachPoint // TypeDefIndex: 11933
{
	// Fields
	public ModelAttachPointType Type; // 0x8
	public Transform Transform; // 0xC

	// Methods

	// RVA: 0x9FDA94 Offset: 0x9FDA94 VA: 0x9FDA94
	public void .ctor() { }
}

// Namespace: SYBO.Common
public enum PromiseState // TypeDefIndex: 11934
{
	// Fields
	public int value__; // 0x0
	public const PromiseState Pending = 0;
	public const PromiseState Rejected = 1;
	public const PromiseState Resolved = 2;
}

// Namespace: SYBO.Common
public interface IPromise // TypeDefIndex: 11935
{
	// Properties
	public abstract PromiseState State { get; }
	public abstract bool Pending { get; }
	public abstract bool Rejected { get; }
	public abstract bool Resolved { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract PromiseState get_State();

	// RVA: -1 Offset: -1 Slot: 1
	public abstract bool get_Pending();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract bool get_Rejected();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract bool get_Resolved();

	// RVA: -1 Offset: -1 Slot: 4
	public abstract void Then(Action<IPromise> handler);
}

// Namespace: SYBO.Common
public interface Promise<V, E> : IPromise // TypeDefIndex: 11936
{
	// Properties
	public abstract V Value { get; }
	public abstract E Error { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract V get_Value();
	/* GenericInstMethod :
	|
	|-RVA: -1 Offset: -1
	|-Promise<object, object>.get_Value
	*/

	// RVA: -1 Offset: -1 Slot: 1
	public abstract E get_Error();
	/* GenericInstMethod :
	|
	|-RVA: -1 Offset: -1
	|-Promise<object, object>.get_Error
	*/

	// RVA: -1 Offset: -1 Slot: 2
	public abstract void Then(Action<Promise<V, E>> handler);
	/* GenericInstMethod :
	|
	|-RVA: -1 Offset: -1
	|-Promise<object, object>.Then
	*/
}

// Namespace: SYBO.Common
public class Deferred : IPromise // TypeDefIndex: 11937
{
	// Fields
	private PromiseState _state; // 0x8
	private List<Action<IPromise>> _handlers; // 0xC

	// Properties
	public IPromise Promise { get; }
	public PromiseState State { get; }
	public bool Pending { get; }
	public bool Rejected { get; }
	public bool Resolved { get; }

	// Methods

	// RVA: 0x60B544 Offset: 0x60B544 VA: 0x60B544
	public IPromise get_Promise() { }

	// RVA: 0x60B548 Offset: 0x60B548 VA: 0x60B548 Slot: 4
	public PromiseState get_State() { }

	// RVA: 0x60B550 Offset: 0x60B550 VA: 0x60B550 Slot: 5
	public bool get_Pending() { }

	// RVA: 0x60B560 Offset: 0x60B560 VA: 0x60B560 Slot: 6
	public bool get_Rejected() { }

	// RVA: 0x60B574 Offset: 0x60B574 VA: 0x60B574 Slot: 7
	public bool get_Resolved() { }

	// RVA: 0x60B588 Offset: 0x60B588 VA: 0x60B588 Slot: 8
	public void Then(Action<IPromise> handler) { }

	// RVA: 0x60B6A0 Offset: 0x60B6A0 VA: 0x60B6A0
	public void Resolve() { }

	// RVA: 0x60B828 Offset: 0x60B828 VA: 0x60B828
	public void Reject() { }

	// RVA: 0x60B6B8 Offset: 0x60B6B8 VA: 0x60B6B8
	private void RunHandlers() { }

	// RVA: 0x60B840 Offset: 0x60B840 VA: 0x60B840
	public void .ctor() { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F814 Offset: 0x36F814 VA: 0x36F814
private sealed class Deferred.<>c__DisplayClass18_0<V, E> // TypeDefIndex: 11938
{
	// Fields
	public Action<IPromise> handler; // 0x0
	public Deferred<V, E> <>4__this; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB6ECE0 Offset: 0xB6ECE0 VA: 0xB6ECE0
	|-Deferred.<>c__DisplayClass18_0<WaitGroup.Empty<object>, object>..ctor
	|
	|-RVA: 0xB6ED78 Offset: 0xB6ED78 VA: 0xB6ED78
	|-Deferred.<>c__DisplayClass18_0<object, object>..ctor
	*/

	// RVA: -1 Offset: -1
	internal void <Then>b__0(Promise<V, E> obj) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB6ED08 Offset: 0xB6ED08 VA: 0xB6ED08
	|-Deferred.<>c__DisplayClass18_0<WaitGroup.Empty<object>, object>.<Then>b__0
	|
	|-RVA: 0xB6EDA0 Offset: 0xB6EDA0 VA: 0xB6EDA0
	|-Deferred.<>c__DisplayClass18_0<object, object>.<Then>b__0
	*/
}

// Namespace: SYBO.Common
public class Deferred<V, E> : Promise<V, E>, IPromise // TypeDefIndex: 11939
{
	// Fields
	private PromiseState _state; // 0x0
	private V _value; // 0x0
	private E _error; // 0x0
	private List<Action<Promise<V, E>>> _handlers; // 0x0

	// Properties
	public Promise<V, E> Promise { get; }
	public PromiseState State { get; }
	public bool Pending { get; }
	public bool Rejected { get; }
	public bool Resolved { get; }
	public V Value { get; }
	public E Error { get; }

	// Methods

	// RVA: -1 Offset: -1
	public Promise<V, E> get_Promise() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xED5F50 Offset: 0xED5F50 VA: 0xED5F50
	|-Deferred<WaitGroup.Empty<object>, object>.get_Promise
	|
	|-RVA: 0xED64B8 Offset: 0xED64B8 VA: 0xED64B8
	|-Deferred<object, object>.get_Promise
	*/

	// RVA: -1 Offset: -1 Slot: 7
	public PromiseState get_State() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xED5F54 Offset: 0xED5F54 VA: 0xED5F54
	|-Deferred<WaitGroup.Empty<object>, object>.get_State
	|
	|-RVA: 0xED64BC Offset: 0xED64BC VA: 0xED64BC
	|-Deferred<object, object>.get_State
	*/

	// RVA: -1 Offset: -1 Slot: 8
	public bool get_Pending() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xED5F5C Offset: 0xED5F5C VA: 0xED5F5C
	|-Deferred<WaitGroup.Empty<object>, object>.get_Pending
	|
	|-RVA: 0xED64C4 Offset: 0xED64C4 VA: 0xED64C4
	|-Deferred<object, object>.get_Pending
	*/

	// RVA: -1 Offset: -1 Slot: 9
	public bool get_Rejected() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xED5F6C Offset: 0xED5F6C VA: 0xED5F6C
	|-Deferred<WaitGroup.Empty<object>, object>.get_Rejected
	|
	|-RVA: 0xED64D4 Offset: 0xED64D4 VA: 0xED64D4
	|-Deferred<object, object>.get_Rejected
	*/

	// RVA: -1 Offset: -1 Slot: 10
	public bool get_Resolved() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xED5F80 Offset: 0xED5F80 VA: 0xED5F80
	|-Deferred<WaitGroup.Empty<object>, object>.get_Resolved
	|
	|-RVA: 0xED64E8 Offset: 0xED64E8 VA: 0xED64E8
	|-Deferred<object, object>.get_Resolved
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public V get_Value() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xED5F94 Offset: 0xED5F94 VA: 0xED5F94
	|-Deferred<WaitGroup.Empty<object>, object>.get_Value
	|
	|-RVA: 0xED64FC Offset: 0xED64FC VA: 0xED64FC
	|-Deferred<object, object>.get_Value
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public E get_Error() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xED5F9C Offset: 0xED5F9C VA: 0xED5F9C
	|-Deferred<WaitGroup.Empty<object>, object>.get_Error
	|
	|-RVA: 0xED6504 Offset: 0xED6504 VA: 0xED6504
	|-Deferred<object, object>.get_Error
	*/

	// RVA: -1 Offset: -1 Slot: 11
	public void Then(Action<IPromise> handler) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xED5FA4 Offset: 0xED5FA4 VA: 0xED5FA4
	|-Deferred<WaitGroup.Empty<object>, object>.Then
	|
	|-RVA: 0xED650C Offset: 0xED650C VA: 0xED650C
	|-Deferred<object, object>.Then
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public void Then(Action<Promise<V, E>> handler) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xED6098 Offset: 0xED6098 VA: 0xED6098
	|-Deferred<WaitGroup.Empty<object>, object>.Then
	|
	|-RVA: 0xED6600 Offset: 0xED6600 VA: 0xED6600
	|-Deferred<object, object>.Then
	*/

	// RVA: -1 Offset: -1
	public void Resolve() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xED6188 Offset: 0xED6188 VA: 0xED6188
	|-Deferred<WaitGroup.Empty<object>, object>.Resolve
	|
	|-RVA: 0xED66F0 Offset: 0xED66F0 VA: 0xED66F0
	|-Deferred<object, object>.Resolve
	*/

	// RVA: -1 Offset: -1
	public void Resolve(V v) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xED61C4 Offset: 0xED61C4 VA: 0xED61C4
	|-Deferred<WaitGroup.Empty<object>, object>.Resolve
	|
	|-RVA: 0xED672C Offset: 0xED672C VA: 0xED672C
	|-Deferred<object, object>.Resolve
	*/

	// RVA: -1 Offset: -1
	public void Reject(E error) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xED623C Offset: 0xED623C VA: 0xED623C
	|-Deferred<WaitGroup.Empty<object>, object>.Reject
	|
	|-RVA: 0xED67A4 Offset: 0xED67A4 VA: 0xED67A4
	|-Deferred<object, object>.Reject
	*/

	// RVA: -1 Offset: -1
	private void RunHandlers() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xED62B4 Offset: 0xED62B4 VA: 0xED62B4
	|-Deferred<WaitGroup.Empty<object>, object>.RunHandlers
	|
	|-RVA: 0xED681C Offset: 0xED681C VA: 0xED681C
	|-Deferred<object, object>.RunHandlers
	*/

	// RVA: -1 Offset: -1
	public void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xED6490 Offset: 0xED6490 VA: 0xED6490
	|-Deferred<WaitGroup.Empty<object>, object>..ctor
	|
	|-RVA: 0xED69F8 Offset: 0xED69F8 VA: 0xED69F8
	|-Deferred<object, object>..ctor
	*/
}

// Namespace: SYBO.Common
public abstract class RunnableDeferred<V, E> : Deferred<V, E> // TypeDefIndex: 11940
{
	// Methods

	// RVA: -1 Offset: -1 Slot: 12
	protected abstract IEnumerator Sequence();
	/* GenericInstMethod :
	|
	|-RVA: -1 Offset: -1
	|-RunnableDeferred<object, object>.Sequence
	*/

	// RVA: -1 Offset: -1
	public void Handle(ICoroutineHandler handler) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFBCFA0 Offset: 0xFBCFA0 VA: 0xFBCFA0
	|-RunnableDeferred<object, object>.Handle
	*/

	// RVA: -1 Offset: -1
	public Promise<V, E> HandleAndReturn(ICoroutineHandler handler) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFBD090 Offset: 0xFBD090 VA: 0xFBD090
	|-RunnableDeferred<object, object>.HandleAndReturn
	*/

	// RVA: -1 Offset: -1
	protected void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFBD0F4 Offset: 0xFBD0F4 VA: 0xFBD0F4
	|-RunnableDeferred<object, object>..ctor
	*/
}

// Namespace: SYBO.Common
public class WaitForPromise : IEnumerator // TypeDefIndex: 11941
{
	// Fields
	protected IPromise[] promises; // 0x8

	// Properties
	public object Current { get; }

	// Methods

	// RVA: 0x9CFDE8 Offset: 0x9CFDE8 VA: 0x9CFDE8
	public void .ctor(IPromise[] promises) { }

	// RVA: 0x9CFE08 Offset: 0x9CFE08 VA: 0x9CFE08 Slot: 5
	public object get_Current() { }

	// RVA: 0x9CFE10 Offset: 0x9CFE10 VA: 0x9CFE10 Slot: 4
	public bool MoveNext() { }

	// RVA: 0x9CFF3C Offset: 0x9CFF3C VA: 0x9CFF3C Slot: 6
	public void Reset() { }
}

// Namespace: 
public struct WaitGroup.Empty<E> // TypeDefIndex: 11942
{}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F824 Offset: 0x36F824 VA: 0x36F824
private sealed class WaitGroup.<>c__DisplayClass16_0<E, PV> // TypeDefIndex: 11943
{
	// Fields
	public WaitGroup<E> <>4__this; // 0x0
	public Promise<PV, E> promise; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB6E984 Offset: 0xB6E984 VA: 0xB6E984
	|-WaitGroup.<>c__DisplayClass16_0<object, object>..ctor
	*/

	// RVA: -1 Offset: -1
	internal void <Add>b__0(Promise<PV, E> _) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB6E9AC Offset: 0xB6E9AC VA: 0xB6E9AC
	|-WaitGroup.<>c__DisplayClass16_0<object, object>.<Add>b__0
	*/
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F834 Offset: 0x36F834 VA: 0x36F834
private sealed class WaitGroup.<>c__DisplayClass17_0<E> // TypeDefIndex: 11944
{
	// Fields
	public Action<IPromise> handler; // 0x0
	public WaitGroup<E> <>4__this; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB6EC48 Offset: 0xB6EC48 VA: 0xB6EC48
	|-WaitGroup.<>c__DisplayClass17_0<object>..ctor
	*/

	// RVA: -1 Offset: -1
	internal void <Then>b__0(Promise<WaitGroup.Empty<E>, E> h) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB6EC70 Offset: 0xB6EC70 VA: 0xB6EC70
	|-WaitGroup.<>c__DisplayClass17_0<object>.<Then>b__0
	*/
}

// Namespace: SYBO.Common
public class WaitGroup<E> : Promise<WaitGroup.Empty<E>, E>, IPromise // TypeDefIndex: 11945
{
	// Fields
	private Deferred<WaitGroup.Empty<E>, E> _deferred; // 0x0
	private bool _staged; // 0x0
	private int _pending; // 0x0

	// Properties
	public WaitGroup.Empty<E> Value { get; }
	public E Error { get; }
	public PromiseState State { get; }
	public bool Pending { get; }
	public bool Rejected { get; }
	public bool Resolved { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 4
	public WaitGroup.Empty<E> get_Value() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x19C766C Offset: 0x19C766C VA: 0x19C766C
	|-WaitGroup<object>.get_Value
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public E get_Error() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x19C76A4 Offset: 0x19C76A4 VA: 0x19C76A4
	|-WaitGroup<object>.get_Error
	*/

	// RVA: -1 Offset: -1 Slot: 7
	public PromiseState get_State() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x19C76DC Offset: 0x19C76DC VA: 0x19C76DC
	|-WaitGroup<object>.get_State
	*/

	// RVA: -1 Offset: -1 Slot: 8
	public bool get_Pending() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x19C7714 Offset: 0x19C7714 VA: 0x19C7714
	|-WaitGroup<object>.get_Pending
	*/

	// RVA: -1 Offset: -1 Slot: 9
	public bool get_Rejected() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x19C774C Offset: 0x19C774C VA: 0x19C774C
	|-WaitGroup<object>.get_Rejected
	*/

	// RVA: -1 Offset: -1 Slot: 10
	public bool get_Resolved() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x19C7784 Offset: 0x19C7784 VA: 0x19C7784
	|-WaitGroup<object>.get_Resolved
	*/

	// RVA: -1 Offset: -1
	public void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x19C77BC Offset: 0x19C77BC VA: 0x19C77BC
	|-WaitGroup<object>..ctor
	*/

	// RVA: -1 Offset: -1
	public void Add<PV>(Promise<PV, E> promise) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x103F4C0 Offset: 0x103F4C0 VA: 0x103F4C0
	|-WaitGroup<object>.Add<object>
	*/

	// RVA: -1 Offset: -1 Slot: 11
	public void Then(Action<IPromise> handler) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x19C783C Offset: 0x19C783C VA: 0x19C783C
	|-WaitGroup<object>.Then
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public void Then(Action<Promise<WaitGroup.Empty<E>, E>> handler) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x19C7930 Offset: 0x19C7930 VA: 0x19C7930
	|-WaitGroup<object>.Then
	*/
}

// Namespace: 
public sealed class Retriable.PromiseMaker<V, E> : MulticastDelegate // TypeDefIndex: 11946
{
	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(object object, IntPtr method) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1A69514 Offset: 0x1A69514 VA: 0x1A69514
	|-Retriable.PromiseMaker<object, object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public virtual Promise<V, E> Invoke(ICoroutineHandler handler) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1A69528 Offset: 0x1A69528 VA: 0x1A69528
	|-Retriable.PromiseMaker<object, object>.Invoke
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public virtual IAsyncResult BeginInvoke(ICoroutineHandler handler, AsyncCallback callback, object object) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1A69928 Offset: 0x1A69928 VA: 0x1A69928
	|-Retriable.PromiseMaker<object, object>.BeginInvoke
	*/

	// RVA: -1 Offset: -1 Slot: 15
	public virtual Promise<V, E> EndInvoke(IAsyncResult result) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1A6994C Offset: 0x1A6994C VA: 0x1A6994C
	|-Retriable.PromiseMaker<object, object>.EndInvoke
	*/
}

// Namespace: 
public sealed class Retriable.PromiseMakerWithoutHandler<V, E> : MulticastDelegate // TypeDefIndex: 11947
{
	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(object object, IntPtr method) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1A69288 Offset: 0x1A69288 VA: 0x1A69288
	|-Retriable.PromiseMakerWithoutHandler<object, object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public virtual Promise<V, E> Invoke() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1A6929C Offset: 0x1A6929C VA: 0x1A6929C
	|-Retriable.PromiseMakerWithoutHandler<object, object>.Invoke
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public virtual IAsyncResult BeginInvoke(AsyncCallback callback, object object) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1A694DC Offset: 0x1A694DC VA: 0x1A694DC
	|-Retriable.PromiseMakerWithoutHandler<object, object>.BeginInvoke
	*/

	// RVA: -1 Offset: -1 Slot: 15
	public virtual Promise<V, E> EndInvoke(IAsyncResult result) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1A69508 Offset: 0x1A69508 VA: 0x1A69508
	|-Retriable.PromiseMakerWithoutHandler<object, object>.EndInvoke
	*/
}

// Namespace: 
public sealed class Retriable.RetryErrorChecker<E> : MulticastDelegate // TypeDefIndex: 11948
{
	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(object object, IntPtr method) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFBB570 Offset: 0xFBB570 VA: 0xFBB570
	|-Retriable.RetryErrorChecker<object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public virtual bool Invoke(E error) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFBB584 Offset: 0xFBB584 VA: 0xFBB584
	|-Retriable.RetryErrorChecker<object>.Invoke
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public virtual IAsyncResult BeginInvoke(E error, AsyncCallback callback, object object) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFBB984 Offset: 0xFBB984 VA: 0xFBB984
	|-Retriable.RetryErrorChecker<object>.BeginInvoke
	*/

	// RVA: -1 Offset: -1 Slot: 15
	public virtual bool EndInvoke(IAsyncResult result) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFBB9A8 Offset: 0xFBB9A8 VA: 0xFBB9A8
	|-Retriable.RetryErrorChecker<object>.EndInvoke
	*/
}

// Namespace: 
public sealed class Retriable.RetryErrorLogger<E> : MulticastDelegate // TypeDefIndex: 11949
{
	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(object object, IntPtr method) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFBB9DC Offset: 0xFBB9DC VA: 0xFBB9DC
	|-Retriable.RetryErrorLogger<object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public virtual void Invoke(E error) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFBB9F0 Offset: 0xFBB9F0 VA: 0xFBB9F0
	|-Retriable.RetryErrorLogger<object>.Invoke
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public virtual IAsyncResult BeginInvoke(E error, AsyncCallback callback, object object) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFBBDE8 Offset: 0xFBBDE8 VA: 0xFBBDE8
	|-Retriable.RetryErrorLogger<object>.BeginInvoke
	*/

	// RVA: -1 Offset: -1 Slot: 15
	public virtual void EndInvoke(IAsyncResult result) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFBBE0C Offset: 0xFBBE0C VA: 0xFBBE0C
	|-Retriable.RetryErrorLogger<object>.EndInvoke
	*/
}

// Namespace: 
public struct Retriable.Config<V, E> // TypeDefIndex: 11950
{
	// Fields
	public int maxRetries; // 0x0
	public Retriable.PromiseMaker<V, E> makePromise; // 0x0
	public Retriable.RetryErrorChecker<E> retryErrorChecker; // 0x0
	public Retriable.RetryErrorLogger<E> retryErrorLogger; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public Promise<V, E> HandleAndReturn(ICoroutineHandler handler) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xEC9814 Offset: 0xEC9814 VA: 0xEC9814
	|-Retriable.Config<object, object>.HandleAndReturn
	*/
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F844 Offset: 0x36F844 VA: 0x36F844
private sealed class Retriable.<>c__DisplayClass7_0<V, E> // TypeDefIndex: 11951
{
	// Fields
	public Retriable.PromiseMakerWithoutHandler<V, E> makePromiseWithoutHandler; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB7A4BC Offset: 0xB7A4BC VA: 0xB7A4BC
	|-Retriable.<>c__DisplayClass7_0<object, object>..ctor
	*/

	// RVA: -1 Offset: -1
	internal Promise<V, E> <Make>b__0(ICoroutineHandler _) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB7A4E4 Offset: 0xB7A4E4 VA: 0xB7A4E4
	|-Retriable.<>c__DisplayClass7_0<object, object>.<Make>b__0
	*/
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F854 Offset: 0x36F854 VA: 0x36F854
private sealed class Retriable.<DoExecute>d__9<V, E> : IEnumerator<object>, IEnumerator, IDisposable // TypeDefIndex: 11952
{
	// Fields
	private int <>1__state; // 0x0
	private object <>2__current; // 0x0
	public Retriable.Config<V, E> config; // 0x0
	public ICoroutineHandler handler; // 0x0
	public Deferred<V, E> deferred; // 0x0
	private int <retries>5__2; // 0x0
	private Promise<V, E> <promise>5__3; // 0x0

	// Properties
	private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	[DebuggerHiddenAttribute] // RVA: 0x3BD96C Offset: 0x3BD96C VA: 0x3BD96C
	// RVA: -1 Offset: -1
	public void .ctor(int <>1__state) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB81790 Offset: 0xB81790 VA: 0xB81790
	|-Retriable.<DoExecute>d__9<object, object>..ctor
	*/

	[DebuggerHiddenAttribute] // RVA: 0x3BD97C Offset: 0x3BD97C VA: 0x3BD97C
	// RVA: -1 Offset: -1 Slot: 5
	private void System.IDisposable.Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB817C0 Offset: 0xB817C0 VA: 0xB817C0
	|-Retriable.<DoExecute>d__9<object, object>.System.IDisposable.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 6
	private bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB817C4 Offset: 0xB817C4 VA: 0xB817C4
	|-Retriable.<DoExecute>d__9<object, object>.MoveNext
	*/

	[DebuggerHiddenAttribute] // RVA: 0x3BD98C Offset: 0x3BD98C VA: 0x3BD98C
	// RVA: -1 Offset: -1 Slot: 4
	private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB81D2C Offset: 0xB81D2C VA: 0xB81D2C
	|-Retriable.<DoExecute>d__9<object, object>.System.Collections.Generic.IEnumerator<System.Object>.get_Current
	*/

	[DebuggerHiddenAttribute] // RVA: 0x3BD99C Offset: 0x3BD99C VA: 0x3BD99C
	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB81D34 Offset: 0xB81D34 VA: 0xB81D34
	|-Retriable.<DoExecute>d__9<object, object>.System.Collections.IEnumerator.Reset
	*/

	[DebuggerHiddenAttribute] // RVA: 0x3BD9AC Offset: 0x3BD9AC VA: 0x3BD9AC
	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xB81D7C Offset: 0xB81D7C VA: 0xB81D7C
	|-Retriable.<DoExecute>d__9<object, object>.System.Collections.IEnumerator.get_Current
	*/
}

// Namespace: SYBO.Common
public static class Retriable // TypeDefIndex: 11953
{
	// Fields
	public const int DefaultMaxRetries = 3;

	// Methods

	// RVA: -1 Offset: -1
	public static Retriable.Config<V, E> Make<V, E>(Retriable.PromiseMaker<V, E> makePromise, Retriable.RetryErrorChecker<E> retryErrorChecker, int maxRetries = 3, Retriable.RetryErrorLogger<E> retryErrorLogger) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xAB1ED8 Offset: 0xAB1ED8 VA: 0xAB1ED8
	|-Retriable.Make<object, object>
	*/

	// RVA: -1 Offset: -1
	public static Retriable.Config<V, E> Make<V, E>(Retriable.PromiseMakerWithoutHandler<V, E> makePromiseWithoutHandler, Retriable.RetryErrorChecker<E> retryErrorChecker, int maxRetries = 3, Retriable.RetryErrorLogger<E> retryErrorLogger) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xAB1E14 Offset: 0xAB1E14 VA: 0xAB1E14
	|-Retriable.Make<object, object>
	*/

	// RVA: -1 Offset: -1
	public static Promise<V, E> Execute<V, E>(ICoroutineHandler handler, Retriable.Config<V, E> config) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xAB1CC0 Offset: 0xAB1CC0 VA: 0xAB1CC0
	|-Retriable.Execute<object, object>
	*/

	[IteratorStateMachineAttribute] // RVA: 0x3BD900 Offset: 0x3BD900 VA: 0x3BD900
	// RVA: -1 Offset: -1
	private static IEnumerator DoExecute<V, E>(ICoroutineHandler handler, Deferred<V, E> deferred, Retriable.Config<V, E> config) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xAB1C10 Offset: 0xAB1C10 VA: 0xAB1C10
	|-Retriable.DoExecute<object, object>
	*/
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36F864 Offset: 0x36F864 VA: 0x36F864
private sealed class ScreenshotTaker.<TakeScreenshotCoroutine>d__10 : IEnumerator<object>, IEnumerator, IDisposable // TypeDefIndex: 11954
{
	// Fields
	private int <>1__state; // 0x8
	private object <>2__current; // 0xC
	public ScreenshotTaker <>4__this; // 0x10

	// Properties
	private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	[DebuggerHiddenAttribute] // RVA: 0x3BDA5C Offset: 0x3BDA5C VA: 0x3BDA5C
	// RVA: 0x80EB8C Offset: 0x80EB8C VA: 0x80EB8C
	public void .ctor(int <>1__state) { }

	[DebuggerHiddenAttribute] // RVA: 0x3BDA6C Offset: 0x3BDA6C VA: 0x3BDA6C
	// RVA: 0x80EBAC Offset: 0x80EBAC VA: 0x80EBAC Slot: 5
	private void System.IDisposable.Dispose() { }

	// RVA: 0x80EBB0 Offset: 0x80EBB0 VA: 0x80EBB0 Slot: 6
	private bool MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BDA7C Offset: 0x3BDA7C VA: 0x3BDA7C
	// RVA: 0x80EDDC Offset: 0x80EDDC VA: 0x80EDDC Slot: 4
	private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BDA8C Offset: 0x3BDA8C VA: 0x3BDA8C
	// RVA: 0x80EDE4 Offset: 0x80EDE4 VA: 0x80EDE4 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }

	[DebuggerHiddenAttribute] // RVA: 0x3BDA9C Offset: 0x3BDA9C VA: 0x3BDA9C
	// RVA: 0x80EE2C Offset: 0x80EE2C VA: 0x80EE2C Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
}

// Namespace: SYBO.Common
public class ScreenshotTaker : MonoBehaviour // TypeDefIndex: 11955
{
	// Fields
	private const string SCREENSHOT_TIME_FORMAT = "HH.mm.ss";
	private const string SCREENSHOT_FILE_FORMAT = "Screenshot - @{0}x - {1}{2}";
	private const string SCREENSHOT_EXTENSION = ".png";
	[SerializeField] // RVA: 0x3AB9A8 Offset: 0x3AB9A8 VA: 0x3AB9A8
	[InspectorHelpBoxAttribute] // RVA: 0x3AB9A8 Offset: 0x3AB9A8 VA: 0x3AB9A8
	[TooltipAttribute] // RVA: 0x3AB9A8 Offset: 0x3AB9A8 VA: 0x3AB9A8
	private string _screenshotPath; // 0xC
	[RangeAttribute] // RVA: 0x3ABA1C Offset: 0x3ABA1C VA: 0x3ABA1C
	[SerializeField] // RVA: 0x3ABA1C Offset: 0x3ABA1C VA: 0x3ABA1C
	private int _supersizeFactor; // 0x10
	[SerializeField] // RVA: 0x3ABA58 Offset: 0x3ABA58 VA: 0x3ABA58
	[TooltipAttribute] // RVA: 0x3ABA58 Offset: 0x3ABA58 VA: 0x3ABA58
	private float _captureInterval; // 0x14
	[TooltipAttribute] // RVA: 0x3ABAA0 Offset: 0x3ABAA0 VA: 0x3ABAA0
	[SerializeField] // RVA: 0x3ABAA0 Offset: 0x3ABAA0 VA: 0x3ABAA0
	private KeyCode _manualCaptureKey; // 0x18
	private float _captureTimer; // 0x1C

	// Methods

	// RVA: 0xBA8398 Offset: 0xBA8398 VA: 0xBA8398
	private void Update() { }

	[ContextMenu] // RVA: 0x3BD9BC Offset: 0x3BD9BC VA: 0x3BD9BC
	// RVA: 0xBA8440 Offset: 0xBA8440 VA: 0xBA8440
	private void TakeScreenshot() { }

	[IteratorStateMachineAttribute] // RVA: 0x3BD9F0 Offset: 0x3BD9F0 VA: 0x3BD9F0
	// RVA: 0xBA8464 Offset: 0xBA8464 VA: 0xBA8464
	private IEnumerator TakeScreenshotCoroutine() { }

	// RVA: 0xBA84DC Offset: 0xBA84DC VA: 0xBA84DC
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class ScriptableObjectSystem : ScriptableObject // TypeDefIndex: 11956
{
	// Methods

	// RVA: 0xBA854C Offset: 0xBA854C VA: 0xBA854C
	protected void Awake() { }

	// RVA: 0xBA8558 Offset: 0xBA8558 VA: 0xBA8558 Slot: 4
	public virtual void Initialize() { }

	// RVA: 0xBA855C Offset: 0xBA855C VA: 0xBA855C Slot: 5
	public virtual void Cleanup() { }

	// RVA: 0xBA8560 Offset: 0xBA8560 VA: 0xBA8560
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class ScriptableObjectWithName : ScriptableObject // TypeDefIndex: 11957
{
	// Fields
	private string _cacheName; // 0xC

	// Properties
	public string CachedName { get; }

	// Methods

	// RVA: 0xBA8568 Offset: 0xBA8568 VA: 0xBA8568
	public string get_CachedName() { }

	// RVA: 0xBA85A4 Offset: 0xBA85A4 VA: 0xBA85A4 Slot: 0
	public override bool Equals(object other) { }

	// RVA: 0xBA86A0 Offset: 0xBA86A0 VA: 0xBA86A0 Slot: 2
	public override int GetHashCode() { }

	// RVA: 0xBA8654 Offset: 0xBA8654 VA: 0xBA8654
	public static bool op_Equality(ScriptableObjectWithName lhs, ScriptableObjectWithName rhs) { }

	// RVA: 0xBA86D4 Offset: 0xBA86D4 VA: 0xBA86D4
	public static bool op_Inequality(ScriptableObjectWithName lhs, ScriptableObjectWithName rhs) { }

	// RVA: 0xBA86E8 Offset: 0xBA86E8 VA: 0xBA86E8
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class ScriptableObjectWithNameComparer : IEqualityComparer<ScriptableObjectWithName> // TypeDefIndex: 11958
{
	// Methods

	// RVA: 0xBA86F0 Offset: 0xBA86F0 VA: 0xBA86F0 Slot: 4
	public bool Equals(ScriptableObjectWithName x, ScriptableObjectWithName y) { }

	// RVA: 0xBA8744 Offset: 0xBA8744 VA: 0xBA8744 Slot: 5
	public int GetHashCode(ScriptableObjectWithName obj) { }

	// RVA: 0xBA878C Offset: 0xBA878C VA: 0xBA878C
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class SetLoopRandomIntParameterBehaviour : StateMachineBehaviour // TypeDefIndex: 11959
{
	// Fields
	[SerializeField] // RVA: 0x3ABAE8 Offset: 0x3ABAE8 VA: 0x3ABAE8
	private string _parameterName; // 0xC
	[SerializeField] // RVA: 0x3ABAF8 Offset: 0x3ABAF8 VA: 0x3ABAF8
	private int _minimum; // 0x10
	[SerializeField] // RVA: 0x3ABB08 Offset: 0x3ABB08 VA: 0x3ABB08
	private int _maximum; // 0x14
	[SerializeField] // RVA: 0x3ABB18 Offset: 0x3ABB18 VA: 0x3ABB18
	private float _cooldown; // 0x18
	private int _randomValue; // 0x1C
	private float _timer; // 0x20

	// Methods

	// RVA: 0x5ADC24 Offset: 0x5ADC24 VA: 0x5ADC24 Slot: 5
	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }

	// RVA: 0x5ADCE8 Offset: 0x5ADCE8 VA: 0x5ADCE8
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class SetRandomFloatParameterBehaviour : StateMachineBehaviour // TypeDefIndex: 11960
{
	// Fields
	[SerializeField] // RVA: 0x3ABB28 Offset: 0x3ABB28 VA: 0x3ABB28
	private string _parameterName; // 0xC
	[SerializeField] // RVA: 0x3ABB38 Offset: 0x3ABB38 VA: 0x3ABB38
	private float _minimum; // 0x10
	[SerializeField] // RVA: 0x3ABB48 Offset: 0x3ABB48 VA: 0x3ABB48
	private float _maximum; // 0x14

	// Methods

	// RVA: 0x5AE02C Offset: 0x5AE02C VA: 0x5AE02C Slot: 9
	public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash) { }

	// RVA: 0x5AE078 Offset: 0x5AE078 VA: 0x5AE078 Slot: 6
	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }

	// RVA: 0x5AE0C4 Offset: 0x5AE0C4 VA: 0x5AE0C4
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class SetRandomIntParameterBehaviour : StateMachineBehaviour // TypeDefIndex: 11961
{
	// Fields
	[SerializeField] // RVA: 0x3ABB58 Offset: 0x3ABB58 VA: 0x3ABB58
	private string _parameterName; // 0xC
	[SerializeField] // RVA: 0x3ABB68 Offset: 0x3ABB68 VA: 0x3ABB68
	private int _minimum; // 0x10
	[SerializeField] // RVA: 0x3ABB78 Offset: 0x3ABB78 VA: 0x3ABB78
	private int _maximum; // 0x14
	private int _randomValue; // 0x18

	// Methods

	// RVA: 0x5AE134 Offset: 0x5AE134 VA: 0x5AE134 Slot: 9
	public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash) { }

	// RVA: 0x5AE188 Offset: 0x5AE188 VA: 0x5AE188
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class SingletonInScenes : MonoBehaviour // TypeDefIndex: 11962
{
	// Fields
	private static SingletonInScenes _instance; // 0x0

	// Methods

	// RVA: 0xA98C60 Offset: 0xA98C60 VA: 0xA98C60
	private void Awake() { }

	// RVA: 0xA98D84 Offset: 0xA98D84 VA: 0xA98D84
	private void OnDestroy() { }

	// RVA: 0xA98E3C Offset: 0xA98E3C VA: 0xA98E3C
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class SingletonMonoBehaviourAsync<T> : MonoBehaviour // TypeDefIndex: 11963
{
	// Fields
	private static bool _shuttingDown; // 0x0
	private static T _instance; // 0x0

	// Properties
	public static T Instance { get; }

	// Methods

	// RVA: -1 Offset: -1
	public static T get_Instance() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1129FB8 Offset: 0x1129FB8 VA: 0x1129FB8
	|-SingletonMonoBehaviourAsync<object>.get_Instance
	*/

	// RVA: -1 Offset: -1
	private static bool HasExecuteInEditModeAttribute() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x112A0C0 Offset: 0x112A0C0 VA: 0x112A0C0
	|-SingletonMonoBehaviourAsync<object>.HasExecuteInEditModeAttribute
	*/

	// RVA: -1 Offset: -1
	private static ExecuteInEditMode GetExecuteInEditModeAttributes() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x112A1E0 Offset: 0x112A1E0 VA: 0x112A1E0
	|-SingletonMonoBehaviourAsync<object>.GetExecuteInEditModeAttributes
	*/

	// RVA: -1 Offset: -1 Slot: 4
	protected virtual void Awake() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x112A310 Offset: 0x112A310 VA: 0x112A310
	|-SingletonMonoBehaviourAsync<object>.Awake
	*/

	// RVA: -1 Offset: -1 Slot: 5
	protected virtual void OnApplicationQuit() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x112A5C4 Offset: 0x112A5C4 VA: 0x112A5C4
	|-SingletonMonoBehaviourAsync<object>.OnApplicationQuit
	*/

	// RVA: -1 Offset: -1 Slot: 6
	protected virtual void OnDestroy() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x112A680 Offset: 0x112A680 VA: 0x112A680
	|-SingletonMonoBehaviourAsync<object>.OnDestroy
	*/

	// RVA: -1 Offset: -1
	public void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x112A73C Offset: 0x112A73C VA: 0x112A73C
	|-SingletonMonoBehaviourAsync<object>..ctor
	*/

	// RVA: -1 Offset: -1
	private static void .cctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x112A764 Offset: 0x112A764 VA: 0x112A764
	|-SingletonMonoBehaviourAsync<object>..cctor
	*/
}

// Namespace: SYBO.Common
[ExtensionAttribute] // RVA: 0x36F874 Offset: 0x36F874 VA: 0x36F874
public static class StringExtensions // TypeDefIndex: 11964
{
	// Methods

	[ExtensionAttribute] // RVA: 0x3BDAAC Offset: 0x3BDAAC VA: 0x3BDAAC
	// RVA: 0x7FFCDC Offset: 0x7FFCDC VA: 0x7FFCDC
	public static string ToCamelCase(string original) { }

	[ExtensionAttribute] // RVA: 0x3BDABC Offset: 0x3BDABC VA: 0x3BDABC
	// RVA: 0x7FFDC4 Offset: 0x7FFDC4 VA: 0x7FFDC4
	public static string ToPascalCase(string original) { }

	[ExtensionAttribute] // RVA: 0x3BDACC Offset: 0x3BDACC VA: 0x3BDACC
	// RVA: 0x7FFEAC Offset: 0x7FFEAC VA: 0x7FFEAC
	public static bool IsEqualsIgnoreCasing(string original, string other) { }
}

// Namespace: SYBO.Common
[ExtensionAttribute] // RVA: 0x36F884 Offset: 0x36F884 VA: 0x36F884
public static class TextMeshProExtensions // TypeDefIndex: 11965
{
	// Methods

	[ExtensionAttribute] // RVA: 0x3BDADC Offset: 0x3BDADC VA: 0x3BDADC
	// RVA: 0x7D6DC0 Offset: 0x7D6DC0 VA: 0x7D6DC0
	public static void TrySetHtmlColor(TMP_Text text, string colorRGB) { }
}

// Namespace: SYBO.Common
[Serializable]
public class ToggleValue<T> // TypeDefIndex: 11966
{
	// Fields
	public bool On; // 0x0
	public T Value; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public static T op_Explicit(ToggleValue<T> tv) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1524068 Offset: 0x1524068 VA: 0x1524068
	|-ToggleValue<bool>.op_Explicit
	|
	|-RVA: 0x15240B0 Offset: 0x15240B0 VA: 0x15240B0
	|-ToggleValue<int>.op_Explicit
	|
	|-RVA: 0x15240F8 Offset: 0x15240F8 VA: 0x15240F8
	|-ToggleValue<object>.op_Explicit
	|
	|-RVA: 0x1524140 Offset: 0x1524140 VA: 0x1524140
	|-ToggleValue<float>.op_Explicit
	*/

	// RVA: -1 Offset: -1
	public void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1524118 Offset: 0x1524118 VA: 0x1524118
	|-ToggleValue<AnimationCurve>..ctor
	|-ToggleValue<Mesh>..ctor
	|-ToggleValue<object>..ctor
	|
	|-RVA: 0x1524088 Offset: 0x1524088 VA: 0x1524088
	|-ToggleValue<bool>..ctor
	|
	|-RVA: 0x15240D0 Offset: 0x15240D0 VA: 0x15240D0
	|-ToggleValue<int>..ctor
	|
	|-RVA: 0x1524160 Offset: 0x1524160 VA: 0x1524160
	|-ToggleValue<float>..ctor
	*/
}

// Namespace: SYBO.Common
[Serializable]
public class ToggleFloat : ToggleValue<float> // TypeDefIndex: 11967
{
	// Methods

	// RVA: 0x7138D0 Offset: 0x7138D0 VA: 0x7138D0
	public void .ctor() { }
}

// Namespace: SYBO.Common
[Serializable]
public class ToggleInt : ToggleValue<int> // TypeDefIndex: 11968
{
	// Methods

	// RVA: 0x713928 Offset: 0x713928 VA: 0x713928
	public void .ctor() { }
}

// Namespace: SYBO.Common
[Serializable]
public class ToggleBool : ToggleValue<bool> // TypeDefIndex: 11969
{
	// Methods

	// RVA: 0x712EC8 Offset: 0x712EC8 VA: 0x712EC8
	public void .ctor() { }
}

// Namespace: SYBO.Common
[Serializable]
public class ToggleAnimationCurve : ToggleValue<AnimationCurve> // TypeDefIndex: 11970
{
	// Methods

	// RVA: 0x712E70 Offset: 0x712E70 VA: 0x712E70
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class CameraFovScreenAspectAdjuster : MonoBehaviour // TypeDefIndex: 11971
{
	// Fields
	[SerializeField] // RVA: 0x3ABB88 Offset: 0x3ABB88 VA: 0x3ABB88
	private Camera _camera; // 0xC
	[SerializeField] // RVA: 0x3ABB98 Offset: 0x3ABB98 VA: 0x3ABB98
	private float _maxAspect; // 0x10
	[SerializeField] // RVA: 0x3ABBA8 Offset: 0x3ABBA8 VA: 0x3ABBA8
	private float _maxFov; // 0x14
	[SerializeField] // RVA: 0x3ABBB8 Offset: 0x3ABBB8 VA: 0x3ABBB8
	private float _scalingAspect; // 0x18
	[SerializeField] // RVA: 0x3ABBC8 Offset: 0x3ABBC8 VA: 0x3ABBC8
	private float _scalingFov; // 0x1C

	// Methods

	// RVA: 0xA50684 Offset: 0xA50684 VA: 0xA50684
	private void OnEnable() { }

	// RVA: 0xA5073C Offset: 0xA5073C VA: 0xA5073C
	private float ComputeFov() { }

	// RVA: 0xA507CC Offset: 0xA507CC VA: 0xA507CC
	private void OnValidate() { }

	// RVA: 0xA50688 Offset: 0xA50688 VA: 0xA50688
	public void RefreshFOV() { }

	// RVA: 0xA50800 Offset: 0xA50800 VA: 0xA50800
	private void RefreshScalingAspect() { }

	// RVA: 0xA50838 Offset: 0xA50838 VA: 0xA50838
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class DetectClickWidget : MonoBehaviour // TypeDefIndex: 11972
{
	// Fields
	[TooltipAttribute] // RVA: 0x3ABBD8 Offset: 0x3ABBD8 VA: 0x3ABBD8
	[SerializeField] // RVA: 0x3ABBD8 Offset: 0x3ABBD8 VA: 0x3ABBD8
	private Camera _referenceCamera; // 0xC
	[SerializeField] // RVA: 0x3ABC20 Offset: 0x3ABC20 VA: 0x3ABC20
	[TooltipAttribute] // RVA: 0x3ABC20 Offset: 0x3ABC20 VA: 0x3ABC20
	private bool _useNegativeAreaCheck; // 0x10
	[SerializeField] // RVA: 0x3ABC68 Offset: 0x3ABC68 VA: 0x3ABC68
	[TooltipAttribute] // RVA: 0x3ABC68 Offset: 0x3ABC68 VA: 0x3ABC68
	private bool _getCameraFromCanvas; // 0x11
	[TooltipAttribute] // RVA: 0x3ABCB0 Offset: 0x3ABCB0 VA: 0x3ABCB0
	[SerializeField] // RVA: 0x3ABCB0 Offset: 0x3ABCB0 VA: 0x3ABCB0
	private bool _activateOnTouchDown; // 0x12
	[SerializeField] // RVA: 0x3ABCF8 Offset: 0x3ABCF8 VA: 0x3ABCF8
	[TooltipAttribute] // RVA: 0x3ABCF8 Offset: 0x3ABCF8 VA: 0x3ABCF8
	private RectTransform _noClickArea; // 0x14
	[SerializeField] // RVA: 0x3ABD40 Offset: 0x3ABD40 VA: 0x3ABD40
	private UnityEvent _onClick; // 0x18
	private bool _isClicking; // 0x1C

	// Methods

	// RVA: 0x60C59C Offset: 0x60C59C VA: 0x60C59C
	private void Start() { }

	// RVA: 0x60C718 Offset: 0x60C718 VA: 0x60C718
	private void OnEnable() { }

	// RVA: 0x60C5A0 Offset: 0x60C5A0 VA: 0x60C5A0
	private void FindCamera() { }

	// RVA: 0x60C71C Offset: 0x60C71C VA: 0x60C71C
	public void AddClickListener(UnityAction action) { }

	// RVA: 0x60C74C Offset: 0x60C74C VA: 0x60C74C
	public void RemoveClickListener(UnityAction action) { }

	// RVA: 0x60C77C Offset: 0x60C77C VA: 0x60C77C
	private void Update() { }

	// RVA: 0x60C84C Offset: 0x60C84C VA: 0x60C84C
	private bool IsOutsideArea() { }

	// RVA: 0x60C970 Offset: 0x60C970 VA: 0x60C970
	public void .ctor() { }
}

// Namespace: 
public enum FilledSlicedImage.FilledSlicedMethod // TypeDefIndex: 11973
{
	// Fields
	public int value__; // 0x0
	public const FilledSlicedImage.FilledSlicedMethod Horizontal = 0;
	public const FilledSlicedImage.FilledSlicedMethod Vertical = 1;
}

// Namespace: SYBO.Common
public class FilledSlicedImage : Image // TypeDefIndex: 11974
{
	// Fields
	private static readonly Vector2[] _verticesScratch; // 0x0
	private static readonly Vector2[] _UVScratch; // 0x4

	// Methods

	// RVA: 0x969314 Offset: 0x969314 VA: 0x969314 Slot: 44
	protected override void OnPopulateMesh(VertexHelper vh) { }

	// RVA: 0x96940C Offset: 0x96940C VA: 0x96940C
	private void GenerateFilledSlicedSprite(Rect drawingDimensions, float fillAmount, VertexHelper vh) { }

	// RVA: 0x969D08 Offset: 0x969D08 VA: 0x969D08
	private Vector4 GetAdjustedBorders(Vector4 border, Rect adjustedRect) { }

	// RVA: 0x96A020 Offset: 0x96A020 VA: 0x96A020
	private void AdjustSlicedFilledSprite(int axis, float filledSize, float totalSize, Vector4 outer, Vector4 inner, Vector4 border, out int segmentStart, out int segmentEnd) { }

	// RVA: 0x96A844 Offset: 0x96A844 VA: 0x96A844
	private void GenerateFilledSlicedSprite(int axis, int segmentStart, int segmentEnd, VertexHelper vh) { }

	// RVA: 0x969B00 Offset: 0x969B00 VA: 0x969B00
	private void GenerateFilledSprite(Rect drawingDimensions, float fillAmount, VertexHelper vh) { }

	// RVA: 0x96ADA8 Offset: 0x96ADA8 VA: 0x96ADA8
	private void AdjustSimpleFill(ref Vector4 v, ref Vector4 uv, float fillAmount) { }

	// RVA: 0x96AB98 Offset: 0x96AB98 VA: 0x96AB98
	private void AddQuad(VertexHelper vh, Vector2 posMin, Vector2 posMax, Color32 color, Vector2 uvMin, Vector2 uvMax) { }

	// RVA: 0x96AE88 Offset: 0x96AE88 VA: 0x96AE88
	public void .ctor() { }

	// RVA: 0x96AF00 Offset: 0x96AF00 VA: 0x96AF00
	private static void .cctor() { }
}

// Namespace: SYBO.Common
public class UIRecycleScrolling : MonoBehaviour // TypeDefIndex: 11975
{
	// Fields
	private static int StaticPoolCount; // 0x0
	[SerializeField] // RVA: 0x3ABD50 Offset: 0x3ABD50 VA: 0x3ABD50
	private ScrollRect _scrollRect; // 0xC
	[SerializeField] // RVA: 0x3ABD60 Offset: 0x3ABD60 VA: 0x3ABD60
	private UIRecycleScrollingUpdateMode _updateMode; // 0x10
	[SerializeField] // RVA: 0x3ABD70 Offset: 0x3ABD70 VA: 0x3ABD70
	private RectTransform _safeZoneRectTransform; // 0x14
	[TooltipAttribute] // RVA: 0x3ABD80 Offset: 0x3ABD80 VA: 0x3ABD80
	[SerializeField] // RVA: 0x3ABD80 Offset: 0x3ABD80 VA: 0x3ABD80
	private bool _doSimpleSafeZoneCheck; // 0x18
	[SerializeField] // RVA: 0x3ABDC8 Offset: 0x3ABDC8 VA: 0x3ABDC8
	private UIRecycleScrollingSlot _scrollingSlotPrefab; // 0x1C
	[SerializeField] // RVA: 0x3ABDD8 Offset: 0x3ABDD8 VA: 0x3ABDD8
	private bool _ignoreSafeZone; // 0x20
	private List<UIRecycleScrollingSlot> _recycleScrollingSlots; // 0x24
	private IRecycleScrollingProvider _provider; // 0x28
	private Rect _safeZoneWorldRect; // 0x2C
	private bool _isDirty; // 0x3C
	private Vector3[] _reusableCornersArray; // 0x40
	private Rect _reusableSlotRect; // 0x44
	private SpawnPool _recycleSlotPool; // 0x54

	// Properties
	public IReadOnlyList<UIRecycleScrollingSlot> RecycleScrollingSlots { get; }

	// Methods

	// RVA: 0x9C1138 Offset: 0x9C1138 VA: 0x9C1138
	public IReadOnlyList<UIRecycleScrollingSlot> get_RecycleScrollingSlots() { }

	// RVA: 0x9C1140 Offset: 0x9C1140 VA: 0x9C1140
	private void Awake() { }

	// RVA: 0x9C11FC Offset: 0x9C11FC VA: 0x9C11FC
	private void CreateOrGetPools() { }

	// RVA: 0x9C13C0 Offset: 0x9C13C0 VA: 0x9C13C0
	private void OnEnable() { }

	// RVA: 0x9C150C Offset: 0x9C150C VA: 0x9C150C
	private void OnDisable() { }

	// RVA: 0x9C1658 Offset: 0x9C1658 VA: 0x9C1658
	public void SetProvider(IRecycleScrollingProvider provider) { }

	// RVA: 0x9C1660 Offset: 0x9C1660 VA: 0x9C1660
	public void NotifyNewData(bool markAsDirty = False) { }

	// RVA: 0x9C215C Offset: 0x9C215C VA: 0x9C215C
	private bool HasValidElement(int i) { }

	// RVA: 0x9C1BB4 Offset: 0x9C1BB4 VA: 0x9C1BB4
	public void NotifyDataReordered() { }

	// RVA: 0x9C2980 Offset: 0x9C2980 VA: 0x9C2980
	public void RefreshElements() { }

	// RVA: 0x9C2B68 Offset: 0x9C2B68 VA: 0x9C2B68
	private void HandleOnScrollRectScroll(Vector2 scroll) { }

	// RVA: 0x9C2B7C Offset: 0x9C2B7C VA: 0x9C2B7C
	private void LateUpdate() { }

	// RVA: 0x9C2C40 Offset: 0x9C2C40 VA: 0x9C2C40
	public void UpdateRecycleScrolling() { }

	// RVA: 0x9C2EA8 Offset: 0x9C2EA8 VA: 0x9C2EA8
	private bool IsInsideSafeRect(UIRecycleScrollingSlot recycleSlot) { }

	// RVA: 0x9C1EF4 Offset: 0x9C1EF4 VA: 0x9C1EF4
	public void CleanupElements(bool cleanupSlots = False) { }

	// RVA: 0x9C3084 Offset: 0x9C3084 VA: 0x9C3084
	public void RemoveSpecificSlot(int slotIndex) { }

	// RVA: 0x9C24EC Offset: 0x9C24EC VA: 0x9C24EC
	private void FreeSlot(UIRecycleScrollingSlot recycleSlot, bool reparentElement) { }

	// RVA: 0x9C263C Offset: 0x9C263C VA: 0x9C263C
	private void FillSlot(UIRecycleScrollingSlot recycleSlot, int index) { }

	// RVA: 0x9C3210 Offset: 0x9C3210 VA: 0x9C3210
	private void ResetElementAnchor(RectTransform elementTransform) { }

	// RVA: 0x9C3320 Offset: 0x9C3320 VA: 0x9C3320
	public void .ctor() { }

	// RVA: 0x9C33E4 Offset: 0x9C33E4 VA: 0x9C33E4
	private static void .cctor() { }
}

// Namespace: SYBO.Common
internal enum UIRecycleScrollingUpdateMode // TypeDefIndex: 11976
{
	// Fields
	public int value__; // 0x0
	public const UIRecycleScrollingUpdateMode OnScroll = 0;
	public const UIRecycleScrollingUpdateMode OnLateUpdate = 1;
	public const UIRecycleScrollingUpdateMode Manual = 2;
}

// Namespace: SYBO.Common
public interface IRecycleScrollingProvider // TypeDefIndex: 11977
{
	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract int GetNumberOfChildren(UIRecycleScrolling scrolling);

	// RVA: -1 Offset: -1 Slot: 1
	public abstract Transform GetElementParent(UIRecycleScrolling scrolling, int index);

	// RVA: -1 Offset: -1 Slot: 2
	public abstract UIRecycleScrollingElement GetElementPrefab(UIRecycleScrolling scrolling, int index);

	// RVA: -1 Offset: -1 Slot: 3
	public abstract void BuildElement(UIRecycleScrollingElement element, int index);
}

// Namespace: SYBO.Common
public class UIRecycleScrollingElement : MonoBehaviour // TypeDefIndex: 11978
{
	// Fields
	[SpaceAttribute] // RVA: 0x3ABDE8 Offset: 0x3ABDE8 VA: 0x3ABDE8
	[SerializeField] // RVA: 0x3ABDE8 Offset: 0x3ABDE8 VA: 0x3ABDE8
	[HeaderAttribute] // RVA: 0x3ABDE8 Offset: 0x3ABDE8 VA: 0x3ABDE8
	private LayoutElement _layoutElement; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x3ABE44 Offset: 0x3ABE44 VA: 0x3ABE44
	private bool <IsInitialized>k__BackingField; // 0x10

	// Properties
	public LayoutElement LayoutElement { get; }
	public bool IsInitialized { get; set; }

	// Methods

	// RVA: 0x9C343C Offset: 0x9C343C VA: 0x9C343C
	public LayoutElement get_LayoutElement() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BDAEC Offset: 0x3BDAEC VA: 0x3BDAEC
	// RVA: 0x9C3444 Offset: 0x9C3444 VA: 0x9C3444
	public bool get_IsInitialized() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BDAFC Offset: 0x3BDAFC VA: 0x3BDAFC
	// RVA: 0x9C344C Offset: 0x9C344C VA: 0x9C344C
	public void set_IsInitialized(bool value) { }

	// RVA: 0x9C3454 Offset: 0x9C3454 VA: 0x9C3454 Slot: 4
	public virtual void InitializeElement() { }

	// RVA: 0x9C3458 Offset: 0x9C3458 VA: 0x9C3458 Slot: 5
	public virtual void CleanupElement() { }

	// RVA: 0x9C345C Offset: 0x9C345C VA: 0x9C345C
	public void .ctor() { }
}

// Namespace: SYBO.Common
[RequireComponent] // RVA: 0x36F894 Offset: 0x36F894 VA: 0x36F894
public class UIRecycleScrollingSlot : MonoBehaviour // TypeDefIndex: 11979
{
	// Fields
	[SerializeField] // RVA: 0x3ABE54 Offset: 0x3ABE54 VA: 0x3ABE54
	private LayoutElement _layoutElement; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x3ABE64 Offset: 0x3ABE64 VA: 0x3ABE64
	private UIRecycleScrollingElement <ElementPrefab>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x3ABE74 Offset: 0x3ABE74 VA: 0x3ABE74
	private UIRecycleScrollingElement <Element>k__BackingField; // 0x14

	// Properties
	public LayoutElement LayoutElement { get; }
	public UIRecycleScrollingElement ElementPrefab { get; set; }
	public UIRecycleScrollingElement Element { get; set; }
	public bool IsFilled { get; }

	// Methods

	// RVA: 0x9C3464 Offset: 0x9C3464 VA: 0x9C3464
	public LayoutElement get_LayoutElement() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BDB0C Offset: 0x3BDB0C VA: 0x3BDB0C
	// RVA: 0x9C346C Offset: 0x9C346C VA: 0x9C346C
	public UIRecycleScrollingElement get_ElementPrefab() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BDB1C Offset: 0x3BDB1C VA: 0x3BDB1C
	// RVA: 0x9C3474 Offset: 0x9C3474 VA: 0x9C3474
	public void set_ElementPrefab(UIRecycleScrollingElement value) { }

	[CompilerGeneratedAttribute] // RVA: 0x3BDB2C Offset: 0x3BDB2C VA: 0x3BDB2C
	// RVA: 0x9C347C Offset: 0x9C347C VA: 0x9C347C
	public UIRecycleScrollingElement get_Element() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BDB3C Offset: 0x3BDB3C VA: 0x3BDB3C
	// RVA: 0x9C3484 Offset: 0x9C3484 VA: 0x9C3484
	public void set_Element(UIRecycleScrollingElement value) { }

	// RVA: 0x9C246C Offset: 0x9C246C VA: 0x9C246C
	public bool get_IsFilled() { }

	// RVA: 0x9C348C Offset: 0x9C348C VA: 0x9C348C
	public void .ctor() { }
}

// Namespace: SYBO.Common
[RequireComponent] // RVA: 0x36F900 Offset: 0x36F900 VA: 0x36F900
public class SafeAreaAnchoring : MonoBehaviour // TypeDefIndex: 11980
{
	// Fields
	[SerializeField] // RVA: 0x3ABE84 Offset: 0x3ABE84 VA: 0x3ABE84
	private SafeAreaAnchoringType _verticalAnchoring; // 0xC
	[SerializeField] // RVA: 0x3ABE94 Offset: 0x3ABE94 VA: 0x3ABE94
	private SafeAreaAnchoringType _horizontalAnchoring; // 0x10
	private RectTransform _rectTransform; // 0x14
	private Canvas _parentCanvas; // 0x18
	private Rect _lastSafeAreaRect; // 0x1C

	// Methods

	// RVA: 0x951D78 Offset: 0x951D78 VA: 0x951D78
	private void Awake() { }

	// RVA: 0x952054 Offset: 0x952054 VA: 0x952054
	private void OnDestroy() { }

	// RVA: 0x951EE4 Offset: 0x951EE4 VA: 0x951EE4
	private void UpdateAnchoring() { }

	// RVA: 0x952160 Offset: 0x952160 VA: 0x952160
	private Vector2 GetMinAnchor() { }

	// RVA: 0x95229C Offset: 0x95229C VA: 0x95229C
	private Vector2 GetMaxAnchor() { }

	// RVA: 0x952410 Offset: 0x952410 VA: 0x952410
	private Rect GetCameraViewportRect() { }

	// RVA: 0x952534 Offset: 0x952534 VA: 0x952534
	public void .ctor() { }
}

// Namespace: SYBO.Common
internal enum SafeAreaAnchoringType // TypeDefIndex: 11981
{
	// Fields
	public int value__; // 0x0
	public const SafeAreaAnchoringType None = 0;
	public const SafeAreaAnchoringType Anchor = 1;
	public const SafeAreaAnchoringType AnchorMirrored = 2;
}

// Namespace: SYBO.Common
[CreateAssetMenuAttribute] // RVA: 0x36F96C Offset: 0x36F96C VA: 0x36F96C
public class SafeAreaProfiles : ScriptableObject // TypeDefIndex: 11982
{
	// Fields
	[SerializeField] // RVA: 0x3ABEA4 Offset: 0x3ABEA4 VA: 0x3ABEA4
	private SafeAreaProfile[] _profiles; // 0xC

	// Methods

	// RVA: 0x95256C Offset: 0x95256C VA: 0x95256C
	public Rect GetSafeAreaForDevice() { }

	// RVA: 0x952664 Offset: 0x952664 VA: 0x952664
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class SafeAreaProvider : UIBehaviour // TypeDefIndex: 11983
{
	// Fields
	public static Vector2 CurrentScreen; // 0x0
	public static Rect CurrentSafeArea; // 0x8
	public static Rect UnitySafeArea; // 0x18
	public static ScreenOrientation CurrentOrientation; // 0x28
	public static Action OnSafeAreaChanged; // 0x2C
	private bool _initialized; // 0xC
	private float _orientationCheckDelay; // 0x10
	[SerializeField] // RVA: 0x3ABEB4 Offset: 0x3ABEB4 VA: 0x3ABEB4
	private SafeAreaProfiles _profiles; // 0x14

	// Methods

	// RVA: 0x95266C Offset: 0x95266C VA: 0x95266C Slot: 4
	protected override void Awake() { }

	// RVA: 0x9526A0 Offset: 0x9526A0 VA: 0x9526A0 Slot: 6
	protected override void Start() { }

	// RVA: 0x952670 Offset: 0x952670 VA: 0x952670
	private void Initialize() { }

	// RVA: 0x9529EC Offset: 0x9529EC VA: 0x9529EC
	public Rect GetCurrentArea() { }

	// RVA: 0x952A78 Offset: 0x952A78 VA: 0x952A78 Slot: 10
	protected override void OnRectTransformDimensionsChange() { }

	// RVA: 0x952A98 Offset: 0x952A98 VA: 0x952A98
	private void Update() { }

	// RVA: 0x95277C Offset: 0x95277C VA: 0x95277C
	private void RefreshArea() { }

	// RVA: 0x9526BC Offset: 0x9526BC VA: 0x9526BC
	private bool RefreshOrientation() { }

	// RVA: 0x952B28 Offset: 0x952B28 VA: 0x952B28
	public void .ctor() { }

	// RVA: 0x952B38 Offset: 0x952B38 VA: 0x952B38
	private static void .cctor() { }
}

// Namespace: SYBO.Common
[Serializable]
public class SafeAreaProfile // TypeDefIndex: 11984
{
	// Fields
	[SerializeField] // RVA: 0x3ABEC4 Offset: 0x3ABEC4 VA: 0x3ABEC4
	private Rect _portraitSafeArea; // 0x8
	[SerializeField] // RVA: 0x3ABED4 Offset: 0x3ABED4 VA: 0x3ABED4
	private Rect _portraitUpsideDownSafeArea; // 0x18
	[SerializeField] // RVA: 0x3ABEE4 Offset: 0x3ABEE4 VA: 0x3ABEE4
	private string _model; // 0x28

	// Properties
	public string Model { get; }
	public Rect PortraitSafeArea { get; }
	public Rect PortraitUpsideDownSafeArea { get; }

	// Methods

	// RVA: 0x95253C Offset: 0x95253C VA: 0x95253C
	public string get_Model() { }

	// RVA: 0x952544 Offset: 0x952544 VA: 0x952544
	public Rect get_PortraitSafeArea() { }

	// RVA: 0x952554 Offset: 0x952554 VA: 0x952554
	public Rect get_PortraitUpsideDownSafeArea() { }

	// RVA: 0x952564 Offset: 0x952564 VA: 0x952564
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class SimpleCallbackStateInfo : StateInfo // TypeDefIndex: 11985
{
	// Fields
	public Action Callback; // 0x8

	// Methods

	// RVA: 0xA93A74 Offset: 0xA93A74 VA: 0xA93A74
	public void .ctor() { }
}

// Namespace: SYBO.Common
[RequireComponent] // RVA: 0x36F9A0 Offset: 0x36F9A0 VA: 0x36F9A0
public class TextMeshProClickLink : MonoBehaviour, IPointerClickHandler, IEventSystemHandler // TypeDefIndex: 11986
{
	// Fields
	public Action<string, int> OnLinkClicked; // 0xC
	private TMP_Text _textComponent; // 0x10

	// Methods

	// RVA: 0x7D6B90 Offset: 0x7D6B90 VA: 0x7D6B90 Slot: 4
	public void OnPointerClick(PointerEventData eventData) { }

	// RVA: 0x7D6DB8 Offset: 0x7D6DB8 VA: 0x7D6DB8
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class UIDialogWindow : Slice // TypeDefIndex: 11987
{
	// Fields
	[SerializeField] // RVA: 0x3ABEF4 Offset: 0x3ABEF4 VA: 0x3ABEF4
	[HeaderAttribute] // RVA: 0x3ABEF4 Offset: 0x3ABEF4 VA: 0x3ABEF4
	private TMP_Text _headerText; // 0x90
	[SerializeField] // RVA: 0x3ABF3C Offset: 0x3ABF3C VA: 0x3ABF3C
	private TMP_Text _contentText; // 0x94
	[HeaderAttribute] // RVA: 0x3ABF4C Offset: 0x3ABF4C VA: 0x3ABF4C
	[SerializeField] // RVA: 0x3ABF4C Offset: 0x3ABF4C VA: 0x3ABF4C
	private GameObject _cornerCloseButton; // 0x98
	[SerializeField] // RVA: 0x3ABF94 Offset: 0x3ABF94 VA: 0x3ABF94
	private TMP_Text _positiveButtonText; // 0x9C
	[SerializeField] // RVA: 0x3ABFA4 Offset: 0x3ABFA4 VA: 0x3ABFA4
	private GameObject _negativeButton; // 0xA0
	[SerializeField] // RVA: 0x3ABFB4 Offset: 0x3ABFB4 VA: 0x3ABFB4
	private TMP_Text _negativeButtonText; // 0xA4
	private UIDialogWindowResult _cornerCloseResult; // 0xA8
	private Action<UIDialogWindowResult> _onResultCallback; // 0xAC
	private bool _reportedResult; // 0xB0

	// Methods

	// RVA: 0x9B9710 Offset: 0x9B9710 VA: 0x9B9710 Slot: 5
	public override void PrepareShow() { }

	// RVA: 0x9B981C Offset: 0x9B981C VA: 0x9B981C Slot: 10
	public override void PrepareHide() { }

	// RVA: 0x9B9914 Offset: 0x9B9914 VA: 0x9B9914
	private void OnEscapeButton() { }

	// RVA: 0x9B99F0 Offset: 0x9B99F0 VA: 0x9B99F0 Slot: 7
	public override void UpdateContext() { }

	// RVA: 0x9B9A1C Offset: 0x9B9A1C VA: 0x9B9A1C Slot: 14
	protected virtual void SetDialogContentFromContext() { }

	// RVA: 0x9B9B64 Offset: 0x9B9B64 VA: 0x9B9B64
	protected void SetDialogContentFromStateInfo(UIDialogWindowStateInfo stateInfo) { }

	// RVA: 0x9B9C9C Offset: 0x9B9C9C VA: 0x9B9C9C
	public void HandleOnClickCornerCloseButton() { }

	// RVA: 0x9B9CA4 Offset: 0x9B9CA4 VA: 0x9B9CA4
	public void ReportPositiveResult() { }

	// RVA: 0x9B9CAC Offset: 0x9B9CAC VA: 0x9B9CAC
	public void ReportNegativeResult() { }

	// RVA: 0x9B991C Offset: 0x9B991C VA: 0x9B991C
	private void ReportResultAndClose(UIDialogWindowResult dialogWindowResult) { }

	// RVA: 0x9B9CB4 Offset: 0x9B9CB4 VA: 0x9B9CB4
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class UIDialogWindowStateInfo : StateInfo // TypeDefIndex: 11988
{
	// Fields
	public UIDialogWindowType DialogWindowType; // 0x8
	public bool ShowCornerCloseButton; // 0xC
	public UIDialogWindowResult CornerCloseButtonResult; // 0x10
	public string HeaderText; // 0x14
	public string ContentText; // 0x18
	public string PositiveButtonText; // 0x1C
	public string NegativeButtonText; // 0x20
	public Action<UIDialogWindowResult> OnResultCallback; // 0x24

	// Methods

	// RVA: 0x9B9F5C Offset: 0x9B9F5C VA: 0x9B9F5C
	public static UIDialogWindowStateInfo AsMessage(string title, string message, string label, bool showCornerButton = False, UIDialogWindowResult cornerButtonResult = 0, Action<UIDialogWindowResult> callback) { }

	// RVA: 0x9BA0A8 Offset: 0x9BA0A8 VA: 0x9BA0A8
	public static UIDialogWindowStateInfo AsChoice(string title, string message, string label, string cancelLabel, bool showCornerButton = False, UIDialogWindowResult cornerButtonResult = 0, Action<UIDialogWindowResult> callback) { }

	// RVA: 0x9BA0A0 Offset: 0x9BA0A0 VA: 0x9BA0A0
	public void .ctor() { }
}

// Namespace: SYBO.Common
public enum UIDialogWindowType // TypeDefIndex: 11989
{
	// Fields
	public int value__; // 0x0
	public const UIDialogWindowType Message = 0;
	public const UIDialogWindowType Choice = 1;
}

// Namespace: SYBO.Common
public enum UIDialogWindowResult // TypeDefIndex: 11990
{
	// Fields
	public int value__; // 0x0
	public const UIDialogWindowResult Positive = 0;
	public const UIDialogWindowResult Negative = 1;
}

// Namespace: SYBO.Common
public class UIElementSpawner : MonoBehaviour // TypeDefIndex: 11991
{
	// Fields
	[SerializeField] // RVA: 0x3ABFC4 Offset: 0x3ABFC4 VA: 0x3ABFC4
	private Transform _elementsRoot; // 0xC
	[SerializeField] // RVA: 0x3ABFD4 Offset: 0x3ABFD4 VA: 0x3ABFD4
	private bool _useSpawnPool; // 0x10
	[SerializeField] // RVA: 0x3ABFE4 Offset: 0x3ABFE4 VA: 0x3ABFE4
	private bool _wipeOnDestroy; // 0x11
	[VisibleIfAttribute] // RVA: 0x3ABFF4 Offset: 0x3ABFF4 VA: 0x3ABFF4
	[SerializeField] // RVA: 0x3ABFF4 Offset: 0x3ABFF4 VA: 0x3ABFF4
	private string _spawnPoolName; // 0x14
	private SpawnPool _spawnPool; // 0x18

	// Methods

	// RVA: 0x9BA9E8 Offset: 0x9BA9E8 VA: 0x9BA9E8
	private void OnDestroy() { }

	// RVA: 0x9BAA98 Offset: 0x9BAA98 VA: 0x9BAA98
	private void PrepareSpawning() { }

	// RVA: -1 Offset: -1
	public T Spawn<T>(T prefab) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x180DB40 Offset: 0x180DB40 VA: 0x180DB40
	|-UIElementSpawner.Spawn<BaseRewardWidget>
	|-UIElementSpawner.Spawn<NonConsumableItemSkinButton>
	|-UIElementSpawner.Spawn<object>
	|-UIElementSpawner.Spawn<PageIndicator>
	|-UIElementSpawner.Spawn<PromotionInfoItem>
	|-UIElementSpawner.Spawn<ScoreMultiplierInfoWidget>
	|-UIElementSpawner.Spawn<TopRunBracketWidget>
	*/

	// RVA: 0x9BABF4 Offset: 0x9BABF4 VA: 0x9BABF4
	public void Despawn(Transform instanceTransform) { }

	// RVA: 0x9BACBC Offset: 0x9BACBC VA: 0x9BACBC
	public void .ctor() { }
}

// Namespace: SYBO.Common
[ExtensionAttribute] // RVA: 0x36FA0C Offset: 0x36FA0C VA: 0x36FA0C
public static class UIExtensions // TypeDefIndex: 11992
{
	// Fields
	private static Vector3[] ObjectCornersHelper; // 0x0

	// Methods

	[ExtensionAttribute] // RVA: 0x3BDB4C Offset: 0x3BDB4C VA: 0x3BDB4C
	// RVA: 0x9BAD68 Offset: 0x9BAD68 VA: 0x9BAD68
	public static void CopyLayout(LayoutElement layoutElement, LayoutElement otherLayoutElement) { }

	[ExtensionAttribute] // RVA: 0x3BDB5C Offset: 0x3BDB5C VA: 0x3BDB5C
	// RVA: 0x9BAF68 Offset: 0x9BAF68 VA: 0x9BAF68
	public static Rect GetWorldRect(RectTransform rectTransform) { }

	[ExtensionAttribute] // RVA: 0x3BDB6C Offset: 0x3BDB6C VA: 0x3BDB6C
	// RVA: 0x9BB09C Offset: 0x9BB09C VA: 0x9BB09C
	public static void GetWorldRectNoAlloc(RectTransform rectTransform, Vector3[] fourCornersArray, ref Rect worldRect) { }

	[ExtensionAttribute] // RVA: 0x3BDB7C Offset: 0x3BDB7C VA: 0x3BDB7C
	// RVA: 0x9BB178 Offset: 0x9BB178 VA: 0x9BB178
	public static void GetLocalRectRelativeTo(RectTransform source, Transform target, Vector3[] fourCornersArray, ref Rect worldRect) { }

	[ExtensionAttribute] // RVA: 0x3BDB8C Offset: 0x3BDB8C VA: 0x3BDB8C
	// RVA: 0x9BB2D8 Offset: 0x9BB2D8 VA: 0x9BB2D8
	public static bool IsInsideViewport(RectTransform target, Camera camera, RectTransform viewport) { }

	// RVA: 0x9BB6C0 Offset: 0x9BB6C0 VA: 0x9BB6C0
	private static void .cctor() { }
}

// Namespace: SYBO.Common
public class UIRotate : MonoBehaviour // TypeDefIndex: 11993
{
	// Fields
	[SerializeField] // RVA: 0x3AC03C Offset: 0x3AC03C VA: 0x3AC03C
	private float _degreesPerSecond; // 0xC

	// Methods

	// RVA: 0x9C3494 Offset: 0x9C3494 VA: 0x9C3494
	private void Update() { }

	// RVA: 0x9C3538 Offset: 0x9C3538 VA: 0x9C3538
	public void .ctor() { }
}

// Namespace: SYBO.Common
[RequireComponent] // RVA: 0x36FA1C Offset: 0x36FA1C VA: 0x36FA1C
[ExecuteInEditMode] // RVA: 0x36FA1C Offset: 0x36FA1C VA: 0x36FA1C
public class UIShineMaterialModifier : MonoBehaviour // TypeDefIndex: 11994
{
	// Fields
	public Material Material; // 0xC
	public Image Image; // 0x10
	[RangeAttribute] // RVA: 0x3AC04C Offset: 0x3AC04C VA: 0x3AC04C
	[SerializeField] // RVA: 0x3AC04C Offset: 0x3AC04C VA: 0x3AC04C
	private float _progress; // 0x14
	[SerializeField] // RVA: 0x3AC088 Offset: 0x3AC088 VA: 0x3AC088
	private bool _runInUpdate; // 0x18
	private float _prevProgress; // 0x1C

	// Methods

	// RVA: 0x9C5238 Offset: 0x9C5238 VA: 0x9C5238
	private void Awake() { }

	// RVA: 0x9C531C Offset: 0x9C531C VA: 0x9C531C
	public void SetProgress(float value) { }

	// RVA: 0x9C542C Offset: 0x9C542C VA: 0x9C542C
	private void Update() { }

	// RVA: 0x9C5558 Offset: 0x9C5558 VA: 0x9C5558
	public void .ctor() { }
}

// Namespace: SYBO.Common
[ExtensionAttribute] // RVA: 0x36FA98 Offset: 0x36FA98 VA: 0x36FA98
public static class UnityExtensions // TypeDefIndex: 11995
{
	// Methods

	[ExtensionAttribute] // RVA: 0x3BDB9C Offset: 0x3BDB9C VA: 0x3BDB9C
	// RVA: 0x9C7204 Offset: 0x9C7204 VA: 0x9C7204
	public static bool IsRuntimeInstantiated(Object obj) { }
}

// Namespace: SYBO.Common
public struct IntComparer : IEqualityComparer<int> // TypeDefIndex: 11996
{
	// Methods

	// RVA: 0xA3B364 Offset: 0xA3B364 VA: 0xA3B364 Slot: 4
	public bool Equals(int x, int y) { }

	// RVA: 0xA3B374 Offset: 0xA3B374 VA: 0xA3B374 Slot: 5
	public int GetHashCode(int obj) { }
}

// Namespace: SYBO.Common
public struct IntPtrComparerComparer : IEqualityComparer<IntPtr> // TypeDefIndex: 11997
{
	// Methods

	// RVA: 0xA3B3A4 Offset: 0xA3B3A4 VA: 0xA3B3A4 Slot: 4
	public bool Equals(IntPtr x, IntPtr y) { }

	// RVA: 0xA3B3B4 Offset: 0xA3B3B4 VA: 0xA3B3B4 Slot: 5
	public int GetHashCode(IntPtr obj) { }
}

// Namespace: SYBO.Common
public class MeshFlipBook : MonoBehaviour // TypeDefIndex: 11998
{
	// Fields
	[SerializeField] // RVA: 0x3AC098 Offset: 0x3AC098 VA: 0x3AC098
	private MeshFilter _targetMeshFilter; // 0xC
	[SerializeField] // RVA: 0x3AC0A8 Offset: 0x3AC0A8 VA: 0x3AC0A8
	private Mesh[] _meshes; // 0x10
	[SerializeField] // RVA: 0x3AC0B8 Offset: 0x3AC0B8 VA: 0x3AC0B8
	private float _loopDuration; // 0x14
	[SerializeField] // RVA: 0x3AC0C8 Offset: 0x3AC0C8 VA: 0x3AC0C8
	private WrapMode _wrapMode; // 0x18
	[SerializeField] // RVA: 0x3AC0D8 Offset: 0x3AC0D8 VA: 0x3AC0D8
	private bool _animate; // 0x1C
	[SerializeField] // RVA: 0x3AC0E8 Offset: 0x3AC0E8 VA: 0x3AC0E8
	private float _animTime; // 0x20

	// Properties
	public bool Animate { get; set; }

	// Methods

	// RVA: 0x797778 Offset: 0x797778 VA: 0x797778
	public bool get_Animate() { }

	// RVA: 0x797780 Offset: 0x797780 VA: 0x797780
	public void set_Animate(bool value) { }

	// RVA: 0x797788 Offset: 0x797788 VA: 0x797788
	private void Awake() { }

	// RVA: 0x7977E0 Offset: 0x7977E0 VA: 0x7977E0
	private void OnEnable() { }

	// RVA: 0x7977EC Offset: 0x7977EC VA: 0x7977EC
	private void Update() { }

	// RVA: 0x7979D0 Offset: 0x7979D0 VA: 0x7979D0
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class MeshMorpher : MonoBehaviour // TypeDefIndex: 11999
{
	// Fields
	[SerializeField] // RVA: 0x3AC0F8 Offset: 0x3AC0F8 VA: 0x3AC0F8
	private MeshFilter _targetMeshFilter; // 0xC
	[SerializeField] // RVA: 0x3AC108 Offset: 0x3AC108 VA: 0x3AC108
	private Mesh[] _morphTargets; // 0x10
	[SerializeField] // RVA: 0x3AC118 Offset: 0x3AC118 VA: 0x3AC118
	private float _loopDuration; // 0x14
	[SerializeField] // RVA: 0x3AC128 Offset: 0x3AC128 VA: 0x3AC128
	private WrapMode _wrapMode; // 0x18
	[SerializeField] // RVA: 0x3AC138 Offset: 0x3AC138 VA: 0x3AC138
	private bool _animate; // 0x1C
	[SerializeField] // RVA: 0x3AC148 Offset: 0x3AC148 VA: 0x3AC148
	private float _animTime; // 0x20
	private Mesh _mesh; // 0x24
	private Vector3[] _vertices; // 0x28
	private Vector3[][] _morphTargetsVertices; // 0x2C

	// Properties
	public bool Animate { get; set; }
	public Mesh[] MorphTargets { get; }

	// Methods

	// RVA: 0x7979E0 Offset: 0x7979E0 VA: 0x7979E0
	public bool get_Animate() { }

	// RVA: 0x7979E8 Offset: 0x7979E8 VA: 0x7979E8
	public void set_Animate(bool value) { }

	// RVA: 0x7979F0 Offset: 0x7979F0 VA: 0x7979F0
	public Mesh[] get_MorphTargets() { }

	// RVA: 0x7979F8 Offset: 0x7979F8 VA: 0x7979F8
	public void Reset() { }

	// RVA: 0x797AA0 Offset: 0x797AA0 VA: 0x797AA0
	private void BuildMesh(int idx1, int idx2, float t) { }

	// RVA: 0x797A08 Offset: 0x797A08 VA: 0x797A08
	private void SetMorph(float t) { }

	// RVA: 0x797C48 Offset: 0x797C48 VA: 0x797C48
	private void Awake() { }

	// RVA: 0x7980F4 Offset: 0x7980F4 VA: 0x7980F4
	private void OnDestroy() { }

	// RVA: 0x798170 Offset: 0x798170 VA: 0x798170
	private void OnEnable() { }

	// RVA: 0x7981B4 Offset: 0x7981B4 VA: 0x7981B4
	private void OnDisable() { }

	// RVA: 0x7981E0 Offset: 0x7981E0 VA: 0x7981E0
	private void Update() { }

	// RVA: 0x798348 Offset: 0x798348 VA: 0x798348
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class VisibleIfAttribute : PropertyAttribute // TypeDefIndex: 12000
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x3AC158 Offset: 0x3AC158 VA: 0x3AC158
	private string <ConditionPropertyPath>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x3AC168 Offset: 0x3AC168 VA: 0x3AC168
	private bool <ReferenceBool>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x3AC178 Offset: 0x3AC178 VA: 0x3AC178
	private int[] <ReferenceInt>k__BackingField; // 0x14

	// Properties
	public string ConditionPropertyPath { get; set; }
	public bool ReferenceBool { get; set; }
	public int[] ReferenceInt { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x3BDBAC Offset: 0x3BDBAC VA: 0x3BDBAC
	// RVA: 0x9CEEBC Offset: 0x9CEEBC VA: 0x9CEEBC
	public string get_ConditionPropertyPath() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BDBBC Offset: 0x3BDBBC VA: 0x3BDBBC
	// RVA: 0x9CEEC4 Offset: 0x9CEEC4 VA: 0x9CEEC4
	public void set_ConditionPropertyPath(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x3BDBCC Offset: 0x3BDBCC VA: 0x3BDBCC
	// RVA: 0x9CEECC Offset: 0x9CEECC VA: 0x9CEECC
	public bool get_ReferenceBool() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BDBDC Offset: 0x3BDBDC VA: 0x3BDBDC
	// RVA: 0x9CEED4 Offset: 0x9CEED4 VA: 0x9CEED4
	public void set_ReferenceBool(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x3BDBEC Offset: 0x3BDBEC VA: 0x3BDBEC
	// RVA: 0x9CEEDC Offset: 0x9CEEDC VA: 0x9CEEDC
	public int[] get_ReferenceInt() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BDBFC Offset: 0x3BDBFC VA: 0x3BDBFC
	// RVA: 0x9CEEE4 Offset: 0x9CEEE4 VA: 0x9CEEE4
	public void set_ReferenceInt(int[] value) { }

	// RVA: 0x9CEEEC Offset: 0x9CEEEC VA: 0x9CEEEC
	public void .ctor(string propertyPath) { }

	// RVA: 0x9CEF14 Offset: 0x9CEF14 VA: 0x9CEF14
	public void .ctor(string propertyPath, bool value) { }

	// RVA: 0x9CEF3C Offset: 0x9CEF3C VA: 0x9CEF3C
	public void .ctor(string propertyPath, int value) { }

	// RVA: 0x9CEFDC Offset: 0x9CEFDC VA: 0x9CEFDC
	public void .ctor(string propertyPath, int[] values) { }
}

// Namespace: SYBO.Common
public class SystemProvider // TypeDefIndex: 12001
{
	// Fields
	public static readonly SystemProvider Instance; // 0x0
	private Dictionary<Type, IGenericSystem> _systemDictionary; // 0x8
	private Dictionary<int, IGenericSystem> _systemintDictionary; // 0xC
	private int _idCounter; // 0x10

	// Methods

	// RVA: 0x807CA8 Offset: 0x807CA8 VA: 0x807CA8
	private void .ctor() { }

	// RVA: 0x807DD0 Offset: 0x807DD0 VA: 0x807DD0
	public int Register(IGenericSystem system) { }

	// RVA: 0x807F2C Offset: 0x807F2C VA: 0x807F2C
	public void Unregister(int id) { }

	// RVA: 0x80813C Offset: 0x80813C VA: 0x80813C
	public IGenericSystem GetSystemById(int id) { }

	// RVA: -1 Offset: -1
	public T GetSystem<T>() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xAB9C0C Offset: 0xAB9C0C VA: 0xAB9C0C
	|-SystemProvider.GetSystem<BoosterSystem>
	|-SystemProvider.GetSystem<EnemySystem>
	|-SystemProvider.GetSystem<HoverboardSystem>
	|-SystemProvider.GetSystem<ISpawnSystem>
	|-SystemProvider.GetSystem<MainCharacterSystem>
	|-SystemProvider.GetSystem<NotEnoughCurrencySystem>
	|-SystemProvider.GetSystem<object>
	|-SystemProvider.GetSystem<PowerSystem>
	|-SystemProvider.GetSystem<ReviveSystem>
	|-SystemProvider.GetSystem<RewardViewSystem>
	|-SystemProvider.GetSystem<RouteGenerationSystem>
	|-SystemProvider.GetSystem<TrainAudioSystem>
	|-SystemProvider.GetSystem<TutorialSystem>
	|-SystemProvider.GetSystem<UIItemVisualsSystem>
	|-SystemProvider.GetSystem<UpgradeSystem>
	|-SystemProvider.GetSystem<ViewConfigSystem>
	*/

	// RVA: 0x8081CC Offset: 0x8081CC VA: 0x8081CC
	private static void .cctor() { }
}

// Namespace: SYBO.Common
public class ChangeLanguagePopupSlice : UIDialogWindow // TypeDefIndex: 12002
{
	// Fields
	[SerializeField] // RVA: 0x3AC188 Offset: 0x3AC188 VA: 0x3AC188
	private ImageLoader _languageImageLoader; // 0xB4

	// Methods

	// RVA: 0x8A9CF0 Offset: 0x8A9CF0 VA: 0x8A9CF0 Slot: 14
	protected override void SetDialogContentFromContext() { }

	// RVA: 0x8A9F04 Offset: 0x8A9F04 VA: 0x8A9F04
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class ChangeLanguagePopupStateInfo : UIDialogWindowStateInfo // TypeDefIndex: 12003
{
	// Fields
	public CultureInfo language; // 0x28

	// Methods

	// RVA: 0x8A9F0C Offset: 0x8A9F0C VA: 0x8A9F0C
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class TextureLoader : AbstractAssetLoaderBehavior<Texture2D> // TypeDefIndex: 12004
{
	// Fields
	[SerializeField] // RVA: 0x3AC198 Offset: 0x3AC198 VA: 0x3AC198
	private Image _spinner; // 0x4C
	[SerializeField] // RVA: 0x3AC1A8 Offset: 0x3AC1A8 VA: 0x3AC1A8
	private RawImage _image; // 0x50
	private Color _originalColor; // 0x54
	private Color _loadingColor; // 0x64
	private Texture2D _defaultImage; // 0x74
	private bool _active; // 0x78
	private RectTransform _spinnerTransform; // 0x7C
	private float _rotation; // 0x80

	// Methods

	// RVA: 0x7D7228 Offset: 0x7D7228 VA: 0x7D7228 Slot: 8
	protected override void OnAwake() { }

	// RVA: 0x7D72F8 Offset: 0x7D72F8 VA: 0x7D72F8 Slot: 4
	protected override void OnRequestStarted() { }

	// RVA: 0x7D741C Offset: 0x7D741C VA: 0x7D741C Slot: 5
	protected override void OnRequestStopped() { }

	// RVA: 0x7D74FC Offset: 0x7D74FC VA: 0x7D74FC Slot: 6
	protected override void OnRequestSuccess(Texture2D asset) { }

	// RVA: 0x7D7588 Offset: 0x7D7588 VA: 0x7D7588 Slot: 7
	protected override void OnRequestError() { }

	// RVA: 0x7D768C Offset: 0x7D768C VA: 0x7D768C
	public void Request(string imageId, Texture2D defaultImage) { }

	// RVA: 0x7D7260 Offset: 0x7D7260 VA: 0x7D7260
	private void GetOriginalColor() { }

	// RVA: 0x7D7368 Offset: 0x7D7368 VA: 0x7D7368
	private void ToogleSpinner(bool activate) { }

	// RVA: 0x7D76F4 Offset: 0x7D76F4 VA: 0x7D76F4
	private void Update() { }

	// RVA: 0x7D77C8 Offset: 0x7D77C8 VA: 0x7D77C8 Slot: 9
	protected override void OnInnerEnabled() { }

	// RVA: 0x7D77CC Offset: 0x7D77CC VA: 0x7D77CC Slot: 10
	protected override void OnInnerDisabled() { }

	// RVA: 0x7D77D0 Offset: 0x7D77D0 VA: 0x7D77D0
	public void .ctor() { }
}

// Namespace: SYBO.Common
public static class UIDialogWindowHelper // TypeDefIndex: 12005
{
	// Fields
	private const string OkKey = "ui.common.ok";
	private const string CancelKey = "ui.common.cancel";
	private const string YesKey = "ui.common.yes";
	private const string NoKey = "ui.common.no";
	private const string LeaveKey = "ui.common.leave";
	private const string StayKey = "ui.common.stay";

	// Properties
	public static string DefaultOKText { get; }
	public static string DefaultCancelText { get; }
	public static string DefaultYesText { get; }
	public static string DefaultNoText { get; }
	public static string DefaultLeaveText { get; }
	public static string DefaultStayText { get; }

	// Methods

	// RVA: 0x9B9CBC Offset: 0x9B9CBC VA: 0x9B9CBC
	public static string get_DefaultOKText() { }

	// RVA: 0x9B9D2C Offset: 0x9B9D2C VA: 0x9B9D2C
	public static string get_DefaultCancelText() { }

	// RVA: 0x9B9D9C Offset: 0x9B9D9C VA: 0x9B9D9C
	public static string get_DefaultYesText() { }

	// RVA: 0x9B9E0C Offset: 0x9B9E0C VA: 0x9B9E0C
	public static string get_DefaultNoText() { }

	// RVA: 0x9B9E7C Offset: 0x9B9E7C VA: 0x9B9E7C
	public static string get_DefaultLeaveText() { }

	// RVA: 0x9B9EEC Offset: 0x9B9EEC VA: 0x9B9EEC
	public static string get_DefaultStayText() { }
}

// Namespace: 
public enum WorkerQueue.Task.TaskState // TypeDefIndex: 12006
{
	// Fields
	public int value__; // 0x0
	public const WorkerQueue.Task.TaskState Queued = 0;
	public const WorkerQueue.Task.TaskState Executing = 1;
	public const WorkerQueue.Task.TaskState Done = 2;
}

// Namespace: 
public class WorkerQueue.Task // TypeDefIndex: 12007
{
	// Fields
	public IEnumerator Enumerator; // 0x8
	public WorkerQueue.Task.TaskState State; // 0xC

	// Methods

	// RVA: 0x2018980 Offset: 0x2018980 VA: 0x2018980
	public void .ctor() { }
}

// Namespace: SYBO.Common
public class WorkerQueue : SingletonMonoBehaviour<WorkerQueue> // TypeDefIndex: 12008
{
	// Fields
	private WorkerQueue.Task _activeTask; // 0x10
	private Queue<WorkerQueue.Task> _tasks; // 0x14
	private Stopwatch _stopwatch; // 0x18
	public float MaxTimePerIteration_ms; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x3AC1B8 Offset: 0x3AC1B8 VA: 0x3AC1B8
	private Action OnWorkDone; // 0x20

	// Properties
	public bool HasQueuedWork { get; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x3BDC0C Offset: 0x3BDC0C VA: 0x3BDC0C
	// RVA: 0x88625C Offset: 0x88625C VA: 0x88625C
	public void add_OnWorkDone(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x3BDC1C Offset: 0x3BDC1C VA: 0x3BDC1C
	// RVA: 0x886308 Offset: 0x886308 VA: 0x886308
	public void remove_OnWorkDone(Action value) { }

	// RVA: 0x8863B4 Offset: 0x8863B4 VA: 0x8863B4
	public bool get_HasQueuedWork() { }

	// RVA: 0x886424 Offset: 0x886424 VA: 0x886424
	public WorkerQueue.Task Enqueue(IEnumerator enumerator) { }

	// RVA: 0x8864F0 Offset: 0x8864F0 VA: 0x8864F0
	public void Process() { }

	// RVA: 0x8867AC Offset: 0x8867AC VA: 0x8867AC
	private void Update() { }

	// RVA: 0x8867B0 Offset: 0x8867B0 VA: 0x8867B0
	public void .ctor() { }
}

// Namespace: SYBO.Common.Utility
public static class Checksum // TypeDefIndex: 12009
{
	// Methods

	// RVA: 0x8C53F0 Offset: 0x8C53F0 VA: 0x8C53F0
	public static byte[] ComputeSHA1(byte[] data) { }

	// RVA: 0x8C555C Offset: 0x8C555C VA: 0x8C555C
	public static byte[] ComputeMD5(byte[] data) { }

	// RVA: 0x8C56C8 Offset: 0x8C56C8 VA: 0x8C56C8
	public static byte[] ComputeSHA256(byte[] data) { }

	// RVA: 0x8C5834 Offset: 0x8C5834 VA: 0x8C5834
	public static byte[] ComputeSHA1(string data, Encoding encoding) { }

	// RVA: 0x8C5884 Offset: 0x8C5884 VA: 0x8C5884
	public static byte[] ComputeMD5(string data, Encoding encoding) { }

	// RVA: 0x8C58D4 Offset: 0x8C58D4 VA: 0x8C58D4
	public static byte[] ComputeSHA256(string data, Encoding encoding) { }
}

// Namespace: SYBO.Common.MaterialTest
public class MaterialPermutationTester : MonoBehaviour // TypeDefIndex: 12010
{
	// Fields
	[SerializeField] // RVA: 0x3AC1C8 Offset: 0x3AC1C8 VA: 0x3AC1C8
	private Shader _shader; // 0xC
	[SerializeField] // RVA: 0x3AC1D8 Offset: 0x3AC1D8 VA: 0x3AC1D8
	private Texture _texture; // 0x10

	// Methods

	// RVA: 0x78EE2C Offset: 0x78EE2C VA: 0x78EE2C
	public void .ctor() { }
}

// Namespace: SYBO.Common.Runtime.UI
[ExecuteInEditMode] // RVA: 0x36FAA8 Offset: 0x36FAA8 VA: 0x36FAA8
[RequireComponent] // RVA: 0x36FAA8 Offset: 0x36FAA8 VA: 0x36FAA8
public class UiOverrideColorModifier : MonoBehaviour // TypeDefIndex: 12011
{
	// Fields
	public Material Material; // 0xC
	public float OverrideIntensity; // 0x10
	private float _lastIntensity; // 0x14

	// Methods

	// RVA: 0x9C6C18 Offset: 0x9C6C18 VA: 0x9C6C18
	private void Update() { }

	// RVA: 0x9C6CEC Offset: 0x9C6CEC VA: 0x9C6CEC
	public void ResetOverride() { }

	// RVA: 0x9C6D88 Offset: 0x9C6D88 VA: 0x9C6D88
	public void .ctor() { }
}

// Namespace: SYBO.Common.Playables
[Serializable]
public class StoryboardClip : PlayableAsset, ITimelineClipAsset // TypeDefIndex: 12012
{
	// Fields
	public StoryboardBehaviour template; // 0xC

	// Properties
	public ClipCaps clipCaps { get; }

	// Methods

	// RVA: 0x7FE11C Offset: 0x7FE11C VA: 0x7FE11C Slot: 9
	public ClipCaps get_clipCaps() { }

	// RVA: 0x7FE124 Offset: 0x7FE124 VA: 0x7FE124 Slot: 6
	public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) { }

	// RVA: 0x7FE224 Offset: 0x7FE224 VA: 0x7FE224
	public void .ctor() { }
}

// Namespace: SYBO.Common.Playables
public class StoryboardMixerBehaviour : PlayableBehaviour // TypeDefIndex: 12013
{
	// Methods

	// RVA: 0x7FE290 Offset: 0x7FE290 VA: 0x7FE290 Slot: 20
	public override void ProcessFrame(Playable playable, FrameData info, object playerData) { }

	// RVA: 0x7FE624 Offset: 0x7FE624 VA: 0x7FE624
	public void .ctor() { }
}

// Namespace: SYBO.Common.Playables
[TrackColorAttribute] // RVA: 0x36FB24 Offset: 0x36FB24 VA: 0x36FB24
[TrackBindingTypeAttribute] // RVA: 0x36FB24 Offset: 0x36FB24 VA: 0x36FB24
[TrackClipTypeAttribute] // RVA: 0x36FB24 Offset: 0x36FB24 VA: 0x36FB24
public class StoryboardTrack : TrackAsset // TypeDefIndex: 12014
{
	// Methods

	// RVA: 0x7FE62C Offset: 0x7FE62C VA: 0x7FE62C Slot: 23
	public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount) { }

	// RVA: 0x7FE720 Offset: 0x7FE720 VA: 0x7FE720
	public void .ctor() { }
}

// Namespace: SYBO.Common.Physics
public class RayCastHelper // TypeDefIndex: 12015
{
	// Fields
	public static readonly RaycastHit[] LastResult; // 0x0
	private static readonly RaycastHit[] MoreResults; // 0x4

	// Methods

	// RVA: 0x90A650 Offset: 0x90A650 VA: 0x90A650
	public static bool Raycast(Vector3 origin, Vector3 direction, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) { }

	// RVA: 0x90A748 Offset: 0x90A748 VA: 0x90A748
	public static bool Raycast(Vector3 origin, Vector3 direction, float distance, int layerMask) { }

	// RVA: 0x90A834 Offset: 0x90A834 VA: 0x90A834
	public static bool Raycast(Vector3 origin, Vector3 direction, int layerMask) { }

	// RVA: 0x90A910 Offset: 0x90A910 VA: 0x90A910
	public static bool Raycast(Ray ray, float distance, int layerMask) { }

	// RVA: 0x90A9FC Offset: 0x90A9FC VA: 0x90A9FC
	public static bool RaycastNearest(Vector3 origin, Vector3 direction, float distance, int layerMask) { }

	// RVA: 0x90ADCC Offset: 0x90ADCC VA: 0x90ADCC
	public void .ctor() { }

	// RVA: 0x90ADD4 Offset: 0x90ADD4 VA: 0x90ADD4
	private static void .cctor() { }
}

// Namespace: SYBO.Common.Memory
public class SafeValue // TypeDefIndex: 12016
{
	// Fields
	public static Random SafeValueRandom; // 0x0

	// Methods

	// RVA: 0x95671C Offset: 0x95671C VA: 0x95671C
	public void .ctor() { }

	// RVA: 0x956724 Offset: 0x956724 VA: 0x956724
	private static void .cctor() { }
}

// Namespace: SYBO.Common.Memory
public struct SafeFloat // TypeDefIndex: 12017
{
	// Fields
	private float _offset; // 0x0
	private float _value; // 0x4

	// Properties
	public float Value { get; set; }

	// Methods

	// RVA: 0x952C2C Offset: 0x952C2C VA: 0x952C2C
	public void .ctor(float value = 0) { }

	// RVA: 0x952CF4 Offset: 0x952CF4 VA: 0x952CF4
	public float get_Value() { }

	// RVA: 0x952D08 Offset: 0x952D08 VA: 0x952D08
	public void set_Value(float value) { }

	// RVA: 0x952D3C Offset: 0x952D3C VA: 0x952D3C
	public void Dispose() { }

	// RVA: 0x952D4C Offset: 0x952D4C VA: 0x952D4C Slot: 3
	public override string ToString() { }

	// RVA: 0x948710 Offset: 0x948710 VA: 0x948710
	public static float op_Implicit(SafeFloat safeFloat) { }

	// RVA: 0x948758 Offset: 0x948758 VA: 0x948758
	public static SafeFloat op_Implicit(float b) { }

	// RVA: 0x94957C Offset: 0x94957C VA: 0x94957C
	public static SafeFloat op_Addition(SafeFloat f1, SafeFloat f2) { }

	// RVA: 0x952DE8 Offset: 0x952DE8 VA: 0x952DE8
	public static SafeFloat op_Addition(SafeFloat f1, SafeInt i2) { }

	// RVA: 0x952E38 Offset: 0x952E38 VA: 0x952E38
	public static SafeFloat op_Addition(SafeInt f1, SafeFloat i2) { }

	// RVA: 0x952E74 Offset: 0x952E74 VA: 0x952E74
	public static SafeFloat op_Increment(SafeFloat f1) { }

	// RVA: 0x952EA8 Offset: 0x952EA8 VA: 0x952EA8
	public static SafeFloat op_Subtraction(SafeFloat f1, SafeFloat f2) { }

	// RVA: 0x952EE4 Offset: 0x952EE4 VA: 0x952EE4
	public static SafeFloat op_Subtraction(SafeFloat f1, SafeInt i2) { }

	// RVA: 0x952F24 Offset: 0x952F24 VA: 0x952F24
	public static SafeFloat op_Subtraction(SafeInt f1, SafeFloat i2) { }

	// RVA: 0x952F60 Offset: 0x952F60 VA: 0x952F60
	public static SafeFloat op_Decrement(SafeFloat f1) { }

	// RVA: 0x952F94 Offset: 0x952F94 VA: 0x952F94
	public static SafeFloat op_Division(SafeFloat f1, SafeFloat f2) { }

	// RVA: 0x952FD0 Offset: 0x952FD0 VA: 0x952FD0
	public static SafeFloat op_Division(SafeFloat f1, SafeInt i2) { }

	// RVA: 0x953010 Offset: 0x953010 VA: 0x953010
	public static SafeFloat op_Division(SafeInt f1, SafeFloat i2) { }

	// RVA: 0x95304C Offset: 0x95304C VA: 0x95304C
	public static SafeFloat op_Multiply(SafeFloat f1, SafeFloat f2) { }

	// RVA: 0x953088 Offset: 0x953088 VA: 0x953088
	public static SafeFloat op_Multiply(SafeFloat f1, SafeInt i2) { }

	// RVA: 0x9530C8 Offset: 0x9530C8 VA: 0x9530C8
	public static SafeFloat op_Multiply(SafeInt f1, SafeFloat i2) { }

	// RVA: 0x953104 Offset: 0x953104 VA: 0x953104
	public static SafeFloat op_Modulus(SafeFloat f1, SafeFloat f2) { }

	// RVA: 0x953150 Offset: 0x953150 VA: 0x953150
	public static SafeFloat op_Modulus(SafeFloat f1, SafeInt i2) { }

	// RVA: 0x9531A0 Offset: 0x9531A0 VA: 0x9531A0
	public static SafeFloat op_Modulus(SafeInt f1, SafeFloat i2) { }

	// RVA: 0x9531EC Offset: 0x9531EC VA: 0x9531EC
	public static bool op_Equality(SafeFloat f1, SafeFloat f2) { }

	// RVA: 0x953218 Offset: 0x953218 VA: 0x953218
	public static bool op_Inequality(SafeFloat f1, SafeFloat f2) { }

	// RVA: 0x953244 Offset: 0x953244 VA: 0x953244
	public static bool op_Equality(SafeFloat f1, SafeInt i2) { }

	// RVA: 0x953270 Offset: 0x953270 VA: 0x953270
	public static bool op_Inequality(SafeFloat f1, SafeInt i2) { }

	// RVA: 0x95329C Offset: 0x95329C VA: 0x95329C
	public static bool op_Equality(SafeFloat f1, SafeLong l2) { }

	// RVA: 0x9532FC Offset: 0x9532FC VA: 0x9532FC
	public static bool op_Inequality(SafeFloat f1, SafeLong l2) { }

	// RVA: 0x953344 Offset: 0x953344 VA: 0x953344
	public static bool op_GreaterThan(SafeFloat f1, SafeFloat f2) { }

	// RVA: 0x953370 Offset: 0x953370 VA: 0x953370
	public static bool op_LessThan(SafeFloat f1, SafeFloat f2) { }

	// RVA: 0x95339C Offset: 0x95339C VA: 0x95339C
	public static bool op_GreaterThanOrEqual(SafeFloat f1, SafeFloat f2) { }

	// RVA: 0x9533C8 Offset: 0x9533C8 VA: 0x9533C8
	public static bool op_LessThanOrEqual(SafeFloat f1, SafeFloat f2) { }

	// RVA: 0x9533F4 Offset: 0x9533F4 VA: 0x9533F4
	public static bool op_GreaterThan(SafeFloat f1, SafeInt i2) { }

	// RVA: 0x953420 Offset: 0x953420 VA: 0x953420
	public static bool op_LessThan(SafeFloat f1, SafeInt i2) { }

	// RVA: 0x95344C Offset: 0x95344C VA: 0x95344C
	public static bool op_GreaterThanOrEqual(SafeFloat f1, SafeInt i2) { }

	// RVA: 0x953478 Offset: 0x953478 VA: 0x953478
	public static bool op_LessThanOrEqual(SafeFloat f1, SafeInt i2) { }

	// RVA: 0x9534A4 Offset: 0x9534A4 VA: 0x9534A4
	public static bool op_GreaterThan(SafeFloat f1, SafeLong l2) { }

	// RVA: 0x9534EC Offset: 0x9534EC VA: 0x9534EC
	public static bool op_LessThan(SafeFloat f1, SafeLong l2) { }

	// RVA: 0x953534 Offset: 0x953534 VA: 0x953534
	public static bool op_GreaterThanOrEqual(SafeFloat f1, SafeLong l2) { }

	// RVA: 0x95357C Offset: 0x95357C VA: 0x95357C
	public static bool op_LessThanOrEqual(SafeFloat f1, SafeLong l2) { }

	// RVA: 0x9535C4 Offset: 0x9535C4 VA: 0x9535C4 Slot: 0
	public override bool Equals(object obj) { }

	// RVA: 0x9538A4 Offset: 0x9538A4 VA: 0x9538A4 Slot: 2
	public override int GetHashCode() { }
}

// Namespace: SYBO.Common.Memory
public struct SafeInt // TypeDefIndex: 12018
{
	// Fields
	private int _offset; // 0x0
	private int _value; // 0x4

	// Properties
	public int Value { get; set; }

	// Methods

	// RVA: 0x9538D4 Offset: 0x9538D4 VA: 0x9538D4
	public void .ctor(int value = 0) { }

	// RVA: 0x952E28 Offset: 0x952E28 VA: 0x952E28
	public int get_Value() { }

	// RVA: 0x953984 Offset: 0x953984 VA: 0x953984
	public void set_Value(int value) { }

	// RVA: 0x9539B8 Offset: 0x9539B8 VA: 0x9539B8
	public void Dispose() { }

	// RVA: 0x9539C8 Offset: 0x9539C8 VA: 0x9539C8 Slot: 3
	public override string ToString() { }

	// RVA: 0x948780 Offset: 0x948780 VA: 0x948780
	public static int op_Implicit(SafeInt safeValue) { }

	// RVA: 0x9489B8 Offset: 0x9489B8 VA: 0x9489B8
	public static SafeInt op_Implicit(int b) { }

	// RVA: 0x953A60 Offset: 0x953A60 VA: 0x953A60
	public static SafeInt op_Addition(SafeInt i1, SafeInt i2) { }

	// RVA: 0x948BD0 Offset: 0x948BD0 VA: 0x948BD0
	public static SafeInt op_Addition(SafeInt i1, int i2) { }

	// RVA: 0x953A8C Offset: 0x953A8C VA: 0x953A8C
	public static SafeInt op_Addition(int i1, SafeInt i2) { }

	// RVA: 0x953AB0 Offset: 0x953AB0 VA: 0x953AB0
	public static SafeInt op_Addition(SafeInt i1, SafeFloat f2) { }

	// RVA: 0x953C20 Offset: 0x953C20 VA: 0x953C20
	public static SafeInt op_Addition(SafeFloat i1, SafeInt f2) { }

	// RVA: 0x953D8C Offset: 0x953D8C VA: 0x953D8C
	public static SafeInt op_Increment(SafeInt i1) { }

	// RVA: 0x953DB0 Offset: 0x953DB0 VA: 0x953DB0
	public static SafeInt op_Subtraction(SafeInt i1, SafeInt i2) { }

	// RVA: 0x948CCC Offset: 0x948CCC VA: 0x948CCC
	public static SafeInt op_Subtraction(SafeInt i1, int i2) { }

	// RVA: 0x953DDC Offset: 0x953DDC VA: 0x953DDC
	public static SafeInt op_Subtraction(int i1, SafeInt i2) { }

	// RVA: 0x953E00 Offset: 0x953E00 VA: 0x953E00
	public static SafeInt op_Subtraction(SafeInt i1, SafeFloat f2) { }

	// RVA: 0x953F70 Offset: 0x953F70 VA: 0x953F70
	public static SafeInt op_Subtraction(SafeFloat i1, SafeInt f2) { }

	// RVA: 0x9540DC Offset: 0x9540DC VA: 0x9540DC
	public static SafeInt op_Decrement(SafeInt i1) { }

	// RVA: 0x954100 Offset: 0x954100 VA: 0x954100
	public static SafeInt op_Division(SafeInt i1, SafeInt i2) { }

	// RVA: 0x954138 Offset: 0x954138 VA: 0x954138
	public static SafeInt op_Division(SafeInt i1, SafeFloat f2) { }

	// RVA: 0x9542A8 Offset: 0x9542A8 VA: 0x9542A8
	public static SafeInt op_Division(SafeFloat i1, SafeInt f2) { }

	// RVA: 0x954414 Offset: 0x954414 VA: 0x954414
	public static SafeInt op_Multiply(SafeInt i1, int i2) { }

	// RVA: 0x954438 Offset: 0x954438 VA: 0x954438
	public static SafeInt op_Multiply(int i1, SafeInt i2) { }

	// RVA: 0x95445C Offset: 0x95445C VA: 0x95445C
	public static SafeInt op_Multiply(SafeInt i1, SafeInt i2) { }

	// RVA: 0x954488 Offset: 0x954488 VA: 0x954488
	public static SafeInt op_Multiply(SafeInt i1, SafeFloat f2) { }

	// RVA: 0x9545F8 Offset: 0x9545F8 VA: 0x9545F8
	public static SafeInt op_Multiply(SafeFloat i1, SafeInt f2) { }

	// RVA: 0x954764 Offset: 0x954764 VA: 0x954764
	public static SafeInt op_Modulus(SafeInt i1, SafeInt i2) { }

	// RVA: 0x954798 Offset: 0x954798 VA: 0x954798
	public static SafeInt op_Modulus(SafeInt i1, SafeFloat f2) { }

	// RVA: 0x954914 Offset: 0x954914 VA: 0x954914
	public static bool op_Equality(SafeInt i1, int i2) { }

	// RVA: 0x954928 Offset: 0x954928 VA: 0x954928
	public static bool op_Inequality(SafeInt i1, int i2) { }

	// RVA: 0x95493C Offset: 0x95493C VA: 0x95493C
	public static bool op_Equality(SafeInt i1, SafeInt i2) { }

	// RVA: 0x954954 Offset: 0x954954 VA: 0x954954
	public static bool op_Inequality(SafeInt i1, SafeInt i2) { }

	// RVA: 0x953840 Offset: 0x953840 VA: 0x953840
	public static bool op_Equality(SafeInt i1, SafeFloat f2) { }

	// RVA: 0x954968 Offset: 0x954968 VA: 0x954968
	public static bool op_Inequality(SafeInt i1, SafeFloat f2) { }

	// RVA: 0x954994 Offset: 0x954994 VA: 0x954994
	public static bool op_Equality(SafeInt i1, SafeLong l2) { }

	// RVA: 0x9549C8 Offset: 0x9549C8 VA: 0x9549C8
	public static bool op_Inequality(SafeInt i1, SafeLong l2) { }

	// RVA: 0x9549F8 Offset: 0x9549F8 VA: 0x9549F8
	public static bool op_GreaterThan(SafeInt i1, SafeInt i2) { }

	// RVA: 0x954A10 Offset: 0x954A10 VA: 0x954A10
	public static bool op_GreaterThan(SafeInt i1, int i2) { }

	// RVA: 0x954A24 Offset: 0x954A24 VA: 0x954A24
	public static bool op_LessThan(SafeInt i1, SafeInt i2) { }

	// RVA: 0x948CF0 Offset: 0x948CF0 VA: 0x948CF0
	public static bool op_LessThan(SafeInt i1, int i2) { }

	// RVA: 0x954A3C Offset: 0x954A3C VA: 0x954A3C
	public static bool op_GreaterThanOrEqual(SafeInt i1, int i2) { }

	// RVA: 0x954A50 Offset: 0x954A50 VA: 0x954A50
	public static bool op_LessThanOrEqual(SafeInt i1, int i2) { }

	// RVA: 0x954A64 Offset: 0x954A64 VA: 0x954A64
	public static bool op_GreaterThanOrEqual(SafeInt i1, SafeInt i2) { }

	// RVA: 0x954A7C Offset: 0x954A7C VA: 0x954A7C
	public static bool op_LessThanOrEqual(SafeInt i1, SafeInt i2) { }

	// RVA: 0x954A94 Offset: 0x954A94 VA: 0x954A94
	public static bool op_GreaterThan(SafeInt i1, SafeFloat f2) { }

	// RVA: 0x954AC0 Offset: 0x954AC0 VA: 0x954AC0
	public static bool op_LessThan(SafeInt i1, SafeFloat f2) { }

	// RVA: 0x954AEC Offset: 0x954AEC VA: 0x954AEC
	public static bool op_GreaterThanOrEqual(SafeInt i1, SafeFloat f2) { }

	// RVA: 0x954B18 Offset: 0x954B18 VA: 0x954B18
	public static bool op_LessThanOrEqual(SafeInt i1, SafeFloat f2) { }

	// RVA: 0x954B44 Offset: 0x954B44 VA: 0x954B44
	public static bool op_GreaterThan(SafeInt i1, SafeLong l2) { }

	// RVA: 0x954B74 Offset: 0x954B74 VA: 0x954B74
	public static bool op_LessThan(SafeInt i1, SafeLong l2) { }

	// RVA: 0x954BA4 Offset: 0x954BA4 VA: 0x954BA4
	public static bool op_GreaterThanOrEqual(SafeInt i1, SafeLong l2) { }

	// RVA: 0x954BD4 Offset: 0x954BD4 VA: 0x954BD4
	public static bool op_LessThanOrEqual(SafeInt i1, SafeLong l2) { }

	// RVA: 0x954C04 Offset: 0x954C04 VA: 0x954C04 Slot: 0
	public override bool Equals(object obj) { }

	// RVA: 0x954EC8 Offset: 0x954EC8 VA: 0x954EC8 Slot: 2
	public override int GetHashCode() { }
}

// Namespace: SYBO.Common.Memory
public struct SafeLong // TypeDefIndex: 12019
{
	// Fields
	private long _offset; // 0x0
	private long _value; // 0x8

	// Properties
	public long Value { get; set; }

	// Methods

	// RVA: 0x954EF8 Offset: 0x954EF8 VA: 0x954EF8
	public void .ctor(long value) { }

	// RVA: 0x9532E4 Offset: 0x9532E4 VA: 0x9532E4
	public long get_Value() { }

	// RVA: 0x954FBC Offset: 0x954FBC VA: 0x954FBC
	public void set_Value(long value) { }

	// RVA: 0x954FF0 Offset: 0x954FF0 VA: 0x954FF0
	public void Dispose() { }

	// RVA: 0x954FFC Offset: 0x954FFC VA: 0x954FFC Slot: 3
	public override string ToString() { }

	// RVA: 0x95509C Offset: 0x95509C VA: 0x95509C
	public static long op_Implicit(SafeLong safeValue) { }

	// RVA: 0x949124 Offset: 0x949124 VA: 0x949124
	public static SafeLong op_Implicit(long b) { }

	// RVA: 0x9550A8 Offset: 0x9550A8 VA: 0x9550A8
	public static SafeLong op_Addition(SafeLong l1, SafeLong l2) { }

	// RVA: 0x9550F8 Offset: 0x9550F8 VA: 0x9550F8
	public static SafeLong op_Addition(SafeLong l1, SafeInt i2) { }

	// RVA: 0x955140 Offset: 0x955140 VA: 0x955140
	public static SafeLong op_Addition(SafeLong l1, SafeFloat f2) { }

	// RVA: 0x9552D4 Offset: 0x9552D4 VA: 0x9552D4
	public static SafeLong op_Increment(SafeLong l1) { }

	// RVA: 0x95530C Offset: 0x95530C VA: 0x95530C
	public static SafeLong op_Subtraction(SafeLong l1, long l2) { }

	// RVA: 0x95534C Offset: 0x95534C VA: 0x95534C
	public static SafeLong op_Subtraction(long l1, SafeLong l2) { }

	// RVA: 0x95538C Offset: 0x95538C VA: 0x95538C
	public static SafeLong op_Subtraction(SafeLong l1, SafeLong l2) { }

	// RVA: 0x9553DC Offset: 0x9553DC VA: 0x9553DC
	public static SafeLong op_Subtraction(SafeLong l1, int i2) { }

	// RVA: 0x955418 Offset: 0x955418 VA: 0x955418
	public static SafeLong op_Subtraction(int l1, SafeLong i2) { }

	// RVA: 0x955450 Offset: 0x955450 VA: 0x955450
	public static SafeLong op_Subtraction(SafeLong l1, SafeInt i2) { }

	// RVA: 0x955494 Offset: 0x955494 VA: 0x955494
	public static SafeLong op_Subtraction(SafeInt l1, SafeLong i2) { }

	// RVA: 0x9554D8 Offset: 0x9554D8 VA: 0x9554D8
	public static SafeLong op_Subtraction(SafeLong l1, SafeFloat f2) { }

	// RVA: 0x955670 Offset: 0x955670 VA: 0x955670
	public static SafeLong op_Subtraction(SafeFloat l1, SafeLong f2) { }

	// RVA: 0x955804 Offset: 0x955804 VA: 0x955804
	public static SafeLong op_Decrement(SafeLong l1) { }

	// RVA: 0x95583C Offset: 0x95583C VA: 0x95583C
	public static SafeLong op_Division(SafeLong l1, SafeLong l2) { }

	// RVA: 0x955898 Offset: 0x955898 VA: 0x955898
	public static SafeLong op_Division(SafeLong l1, SafeInt i2) { }

	// RVA: 0x9558F0 Offset: 0x9558F0 VA: 0x9558F0
	public static SafeLong op_Division(SafeLong l1, SafeFloat f2) { }

	// RVA: 0x955A84 Offset: 0x955A84 VA: 0x955A84
	public static SafeLong op_Multiply(SafeLong l1, SafeLong l2) { }

	// RVA: 0x955AD4 Offset: 0x955AD4 VA: 0x955AD4
	public static SafeLong op_Multiply(SafeLong l1, SafeInt i2) { }

	// RVA: 0x955B20 Offset: 0x955B20 VA: 0x955B20
	public static SafeLong op_Multiply(SafeLong l1, SafeFloat f2) { }

	// RVA: 0x955CB4 Offset: 0x955CB4 VA: 0x955CB4
	public static SafeLong op_Modulus(SafeLong l1, SafeLong l2) { }

	// RVA: 0x955D08 Offset: 0x955D08 VA: 0x955D08
	public static SafeLong op_Modulus(SafeLong l1, SafeInt i2) { }

	// RVA: 0x955D58 Offset: 0x955D58 VA: 0x955D58
	public static SafeLong op_Modulus(SafeLong l1, SafeFloat f2) { }

	// RVA: 0x9415DC Offset: 0x9415DC VA: 0x9415DC
	public static bool op_Equality(SafeLong l1, int l2) { }

	// RVA: 0x955EEC Offset: 0x955EEC VA: 0x955EEC
	public static bool op_Inequality(SafeLong l1, int l2) { }

	// RVA: 0x955F0C Offset: 0x955F0C VA: 0x955F0C
	public static bool op_Equality(SafeLong l1, long l2) { }

	// RVA: 0x955F3C Offset: 0x955F3C VA: 0x955F3C
	public static bool op_Inequality(SafeLong l1, long l2) { }

	// RVA: 0x955F68 Offset: 0x955F68 VA: 0x955F68
	public static bool op_Equality(SafeLong l1, SafeLong l2) { }

	// RVA: 0x955FA8 Offset: 0x955FA8 VA: 0x955FA8
	public static bool op_Inequality(SafeLong l1, SafeLong l2) { }

	// RVA: 0x954E94 Offset: 0x954E94 VA: 0x954E94
	public static bool op_Equality(SafeLong l1, SafeInt i2) { }

	// RVA: 0x955FE4 Offset: 0x955FE4 VA: 0x955FE4
	public static bool op_Inequality(SafeLong l1, SafeInt i2) { }

	// RVA: 0x95386C Offset: 0x95386C VA: 0x95386C
	public static bool op_Equality(SafeLong l1, SafeFloat f2) { }

	// RVA: 0x956014 Offset: 0x956014 VA: 0x956014
	public static bool op_Inequality(SafeLong l1, SafeFloat f2) { }

	// RVA: 0x95604C Offset: 0x95604C VA: 0x95604C
	public static bool op_GreaterThan(SafeLong l1, int l2) { }

	// RVA: 0x95606C Offset: 0x95606C VA: 0x95606C
	public static bool op_LessThan(SafeLong l1, int l2) { }

	// RVA: 0x95608C Offset: 0x95608C VA: 0x95608C
	public static bool op_GreaterThan(SafeLong l1, long l2) { }

	// RVA: 0x9560B8 Offset: 0x9560B8 VA: 0x9560B8
	public static bool op_LessThan(SafeLong l1, long l2) { }

	// RVA: 0x949144 Offset: 0x949144 VA: 0x949144
	public static bool op_GreaterThan(SafeLong l1, SafeLong l2) { }

	// RVA: 0x9560E4 Offset: 0x9560E4 VA: 0x9560E4
	public static bool op_LessThan(SafeLong l1, SafeLong l2) { }

	// RVA: 0x956120 Offset: 0x956120 VA: 0x956120
	public static bool op_GreaterThanOrEqual(SafeLong l1, long l2) { }

	// RVA: 0x95614C Offset: 0x95614C VA: 0x95614C
	public static bool op_LessThanOrEqual(SafeLong l1, long l2) { }

	// RVA: 0x956178 Offset: 0x956178 VA: 0x956178
	public static bool op_GreaterThanOrEqual(SafeLong l1, int l2) { }

	// RVA: 0x956198 Offset: 0x956198 VA: 0x956198
	public static bool op_LessThanOrEqual(SafeLong l1, int l2) { }

	// RVA: 0x9561B8 Offset: 0x9561B8 VA: 0x9561B8
	public static bool op_GreaterThanOrEqual(SafeLong l1, SafeLong l2) { }

	// RVA: 0x9561F4 Offset: 0x9561F4 VA: 0x9561F4
	public static bool op_LessThanOrEqual(SafeLong l1, SafeLong l2) { }

	// RVA: 0x956230 Offset: 0x956230 VA: 0x956230
	public static bool op_GreaterThan(SafeLong l1, SafeInt i2) { }

	// RVA: 0x956260 Offset: 0x956260 VA: 0x956260
	public static bool op_LessThan(SafeLong l1, SafeInt i2) { }

	// RVA: 0x956290 Offset: 0x956290 VA: 0x956290
	public static bool op_GreaterThanOrEqual(SafeLong l1, SafeInt i2) { }

	// RVA: 0x9562C0 Offset: 0x9562C0 VA: 0x9562C0
	public static bool op_LessThanOrEqual(SafeLong l1, SafeInt i2) { }

	// RVA: 0x9562F0 Offset: 0x9562F0 VA: 0x9562F0
	public static bool op_GreaterThan(SafeLong l1, SafeFloat f2) { }

	// RVA: 0x956328 Offset: 0x956328 VA: 0x956328
	public static bool op_LessThan(SafeLong l1, SafeFloat f2) { }

	// RVA: 0x956360 Offset: 0x956360 VA: 0x956360
	public static bool op_GreaterThanOrEqual(SafeLong l1, SafeFloat f2) { }

	// RVA: 0x956398 Offset: 0x956398 VA: 0x956398
	public static bool op_LessThanOrEqual(SafeLong l1, SafeFloat f2) { }

	// RVA: 0x9563D0 Offset: 0x9563D0 VA: 0x9563D0 Slot: 0
	public override bool Equals(object obj) { }

	// RVA: 0x9566E4 Offset: 0x9566E4 VA: 0x9566E4 Slot: 2
	public override int GetHashCode() { }
}

// Namespace: SYBO.Common.DeviceRating
public class FlagEnumCustomDrawer : PropertyAttribute // TypeDefIndex: 12020
{
	// Methods

	// RVA: 0x96E274 Offset: 0x96E274 VA: 0x96E274
	public void .ctor() { }
}

// Namespace: SimpleDiskUtils
public class DiskUtils // TypeDefIndex: 12021
{
	// Methods

	// RVA: 0x60FDA4 Offset: 0x60FDA4 VA: 0x60FDA4
	public static int GetAvailableSpaceInMb() { }

	// RVA: 0x60FEC0 Offset: 0x60FEC0 VA: 0x60FEC0
	public static int CheckAvailableSpace(bool isExternalStorage = True) { }

	// RVA: 0x610054 Offset: 0x610054 VA: 0x610054
	public static int CheckTotalSpace(bool isExternalStorage = True) { }

	// RVA: 0x6101E8 Offset: 0x6101E8 VA: 0x6101E8
	public static int CheckBusySpace(bool isExternalStorage = True) { }

	// RVA: 0x61037C Offset: 0x61037C VA: 0x61037C
	public static void DeleteFile(string filePath) { }

	// RVA: 0x6103A8 Offset: 0x6103A8 VA: 0x6103A8
	public static void SaveFile(object obj, string filePath) { }

	// RVA: 0x610568 Offset: 0x610568 VA: 0x610568
	public static void SaveFile(object obj, string dirPath, string fileName) { }

	// RVA: -1 Offset: -1
	public static T LoadFile<T>(string filePath) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x676098 Offset: 0x676098 VA: 0x676098
	|-DiskUtils.LoadFile<object>
	*/

	// RVA: 0x610990 Offset: 0x610990 VA: 0x610990
	public static void SaveTextFile(string str, string filePath) { }

	// RVA: 0x610A9C Offset: 0x610A9C VA: 0x610A9C
	public static void SaveTextFile(string str, string dirPath, string fileName) { }

	// RVA: -1 Offset: -1
	public static string LoadTextFile<T>(string filePath) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x6760E0 Offset: 0x6760E0 VA: 0x6760E0
	|-DiskUtils.LoadTextFile<object>
	*/

	// RVA: 0x61072C Offset: 0x61072C VA: 0x61072C
	public static byte[] ObjectToByteArray(object obj) { }

	// RVA: -1 Offset: -1
	public static T ByteArrayToObject<T>(byte[] bytes) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x675DFC Offset: 0x675DFC VA: 0x675DFC
	|-DiskUtils.ByteArrayToObject<object>
	*/

	// RVA: 0x610C0C Offset: 0x610C0C VA: 0x610C0C
	public void .ctor() { }
}

// Namespace: 
private interface PreciseLocale.PlatformBridge // TypeDefIndex: 12022
{
	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract string GetRegion();

	// RVA: -1 Offset: -1 Slot: 1
	public abstract string GetLanguage();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract string GetLanguageID();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract string GetCurrencyCode();

	// RVA: -1 Offset: -1 Slot: 4
	public abstract string GetCurrencySymbol();
}

// Namespace: 
private class PreciseLocale.EditorBridge : PreciseLocale.PlatformBridge // TypeDefIndex: 12023
{
	// Methods

	// RVA: 0x8D55D4 Offset: 0x8D55D4 VA: 0x8D55D4 Slot: 4
	public string GetRegion() { }

	// RVA: 0x8D5620 Offset: 0x8D5620 VA: 0x8D5620 Slot: 5
	public string GetLanguage() { }

	// RVA: 0x8D566C Offset: 0x8D566C VA: 0x8D566C Slot: 6
	public string GetLanguageID() { }

	// RVA: 0x8D56B8 Offset: 0x8D56B8 VA: 0x8D56B8 Slot: 7
	public string GetCurrencyCode() { }

	// RVA: 0x8D5704 Offset: 0x8D5704 VA: 0x8D5704 Slot: 8
	public string GetCurrencySymbol() { }

	// RVA: 0x8D5750 Offset: 0x8D5750 VA: 0x8D5750
	public void .ctor() { }
}

// Namespace: 
private class PreciseLocale.PreciseLocaleAndroid : PreciseLocale.PlatformBridge // TypeDefIndex: 12024
{
	// Fields
	private static AndroidJavaClass _preciseLocale; // 0x0

	// Methods

	// RVA: 0x8D5758 Offset: 0x8D5758 VA: 0x8D5758 Slot: 4
	public string GetRegion() { }

	// RVA: 0x8D58DC Offset: 0x8D58DC VA: 0x8D58DC Slot: 5
	public string GetLanguage() { }

	// RVA: 0x8D5A60 Offset: 0x8D5A60 VA: 0x8D5A60 Slot: 6
	public string GetLanguageID() { }

	// RVA: 0x8D5BE4 Offset: 0x8D5BE4 VA: 0x8D5BE4 Slot: 7
	public string GetCurrencyCode() { }

	// RVA: 0x8D5D68 Offset: 0x8D5D68 VA: 0x8D5D68 Slot: 8
	public string GetCurrencySymbol() { }

	// RVA: 0x8D5EEC Offset: 0x8D5EEC VA: 0x8D5EEC
	public void .ctor() { }

	// RVA: 0x8D5EF4 Offset: 0x8D5EF4 VA: 0x8D5EF4
	private static void .cctor() { }
}

// Namespace: Kokosoft
public class PreciseLocale // TypeDefIndex: 12025
{
	// Fields
	private static PreciseLocale.PlatformBridge _platform; // 0x0

	// Properties
	private static PreciseLocale.PlatformBridge platform { get; }

	// Methods

	// RVA: 0x5D63CC Offset: 0x5D63CC VA: 0x5D63CC
	private static PreciseLocale.PlatformBridge get_platform() { }

	// RVA: 0x5D6470 Offset: 0x5D6470 VA: 0x5D6470
	public static string GetRegion() { }

	// RVA: 0x5D6538 Offset: 0x5D6538 VA: 0x5D6538
	public static string GetLanguageID() { }

	// RVA: 0x5D6600 Offset: 0x5D6600 VA: 0x5D6600
	public static string GetLanguage() { }

	// RVA: 0x5D66C8 Offset: 0x5D66C8 VA: 0x5D66C8
	public static string GetCurrencyCode() { }

	// RVA: 0x5D6790 Offset: 0x5D6790 VA: 0x5D6790
	public static string GetCurrencySymbol() { }

	// RVA: 0x5D6858 Offset: 0x5D6858 VA: 0x5D6858
	public void .ctor() { }
}

// Namespace: 
public enum UIParticle.AnimatableProperty.ShaderPropertyType // TypeDefIndex: 12026
{
	// Fields
	public int value__; // 0x0
	public const UIParticle.AnimatableProperty.ShaderPropertyType Color = 0;
	public const UIParticle.AnimatableProperty.ShaderPropertyType Vector = 1;
	public const UIParticle.AnimatableProperty.ShaderPropertyType Float = 2;
	public const UIParticle.AnimatableProperty.ShaderPropertyType Range = 3;
	public const UIParticle.AnimatableProperty.ShaderPropertyType Texture = 4;
}

// Namespace: 
[Serializable]
public class UIParticle.AnimatableProperty : ISerializationCallbackReceiver // TypeDefIndex: 12027
{
	// Fields
	[SerializeField] // RVA: 0x3AC380 Offset: 0x3AC380 VA: 0x3AC380
	private string m_Name; // 0x8
	[SerializeField] // RVA: 0x3AC390 Offset: 0x3AC390 VA: 0x3AC390
	private UIParticle.AnimatableProperty.ShaderPropertyType m_Type; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x3AC3A0 Offset: 0x3AC3A0 VA: 0x3AC3A0
	private int <id>k__BackingField; // 0x10

	// Properties
	public int id { get; set; }
	public UIParticle.AnimatableProperty.ShaderPropertyType type { get; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x3BDC2C Offset: 0x3BDC2C VA: 0x3BDC2C
	// RVA: 0x20180D4 Offset: 0x20180D4 VA: 0x20180D4
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x3BDC3C Offset: 0x3BDC3C VA: 0x3BDC3C
	// RVA: 0x20180DC Offset: 0x20180DC VA: 0x20180DC
	private void set_id(int value) { }

	// RVA: 0x20180E4 Offset: 0x20180E4 VA: 0x20180E4
	public UIParticle.AnimatableProperty.ShaderPropertyType get_type() { }

	// RVA: 0x20180EC Offset: 0x20180EC VA: 0x20180EC Slot: 4
	public void OnBeforeSerialize() { }

	// RVA: 0x20180F0 Offset: 0x20180F0 VA: 0x20180F0 Slot: 5
	public void OnAfterDeserialize() { }

	// RVA: 0x2018110 Offset: 0x2018110 VA: 0x2018110
	public void .ctor() { }
}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36FC10 Offset: 0x36FC10 VA: 0x36FC10
[Serializable]
private sealed class UIParticle.<>c // TypeDefIndex: 12028
{
	// Fields
	public static readonly UIParticle.<>c <>9; // 0x0
	public static Predicate<UIParticle> <>9__48_0; // 0x4

	// Methods

	// RVA: 0x2017FE8 Offset: 0x2017FE8 VA: 0x2017FE8
	private static void .cctor() { }

	// RVA: 0x2018050 Offset: 0x2018050 VA: 0x2018050
	public void .ctor() { }

	// RVA: 0x2018058 Offset: 0x2018058 VA: 0x2018058
	internal bool <SetParent>b__48_0(UIParticle x) { }
}

// Namespace: Coffee.UIExtensions
[ExecuteInEditMode] // RVA: 0x36FC00 Offset: 0x36FC00 VA: 0x36FC00
public class UIParticle : MaskableGraphic // TypeDefIndex: 12029
{
	// Fields
	private static readonly int s_IdMainTex; // 0x0
	private static readonly List<Vector3> s_Vertices; // 0x4
	private static readonly List<Color32> s_Colors; // 0x8
	private static readonly List<UIParticle> s_TempRelatables; // 0xC
	private static readonly List<UIParticle> s_ActiveParticles; // 0x10
	[TooltipAttribute] // RVA: 0x3AC1E8 Offset: 0x3AC1E8 VA: 0x3AC1E8
	[SerializeField] // RVA: 0x3AC1E8 Offset: 0x3AC1E8 VA: 0x3AC1E8
	private ParticleSystem m_ParticleSystem; // 0x7C
	[TooltipAttribute] // RVA: 0x3AC230 Offset: 0x3AC230 VA: 0x3AC230
	[SerializeField] // RVA: 0x3AC230 Offset: 0x3AC230 VA: 0x3AC230
	private UIParticle m_TrailParticle; // 0x80
	[SerializeField] // RVA: 0x3AC278 Offset: 0x3AC278 VA: 0x3AC278
	[HideInInspector] // RVA: 0x3AC278 Offset: 0x3AC278 VA: 0x3AC278
	private bool m_IsTrail; // 0x84
	[SerializeField] // RVA: 0x3AC2A8 Offset: 0x3AC2A8 VA: 0x3AC2A8
	[TooltipAttribute] // RVA: 0x3AC2A8 Offset: 0x3AC2A8 VA: 0x3AC2A8
	private float m_Scale; // 0x88
	[SerializeField] // RVA: 0x3AC2F0 Offset: 0x3AC2F0 VA: 0x3AC2F0
	[TooltipAttribute] // RVA: 0x3AC2F0 Offset: 0x3AC2F0 VA: 0x3AC2F0
	private bool m_IgnoreParent; // 0x8C
	[TooltipAttribute] // RVA: 0x3AC338 Offset: 0x3AC338 VA: 0x3AC338
	[SerializeField] // RVA: 0x3AC338 Offset: 0x3AC338 VA: 0x3AC338
	private UIParticle.AnimatableProperty[] m_AnimatableProperties; // 0x90
	private static MaterialPropertyBlock s_Mpb; // 0x14
	private Mesh _mesh; // 0x94
	private ParticleSystemRenderer _renderer; // 0x98
	private UIParticle _parent; // 0x9C
	private List<UIParticle> _children; // 0xA0
	private Matrix4x4 scaleaMatrix; // 0xA4
	private Vector3 _oldPos; // 0xE4
	private static readonly Vector3 minimumVec3; // 0x18
	private static ParticleSystem.Particle[] s_Particles; // 0x24

	// Properties
	public override Texture mainTexture { get; }
	public override Material material { get; set; }
	public float scale { get; set; }
	public bool ignoreParent { get; set; }
	public bool isRoot { get; }
	public override bool raycastTarget { get; set; }
	public ParticleSystem cachedParticleSystem { get; }

	// Methods

	// RVA: 0x9BCA80 Offset: 0x9BCA80 VA: 0x9BCA80 Slot: 35
	public override Texture get_mainTexture() { }

	// RVA: 0x9BCEC0 Offset: 0x9BCEC0 VA: 0x9BCEC0 Slot: 32
	public override Material get_material() { }

	// RVA: 0x9BCF7C Offset: 0x9BCF7C VA: 0x9BCF7C Slot: 33
	public override void set_material(Material value) { }

	// RVA: 0x9BD128 Offset: 0x9BD128 VA: 0x9BD128
	public float get_scale() { }

	// RVA: 0x9BD1BC Offset: 0x9BD1BC VA: 0x9BD1BC
	public void set_scale(float value) { }

	// RVA: 0x9BD1C4 Offset: 0x9BD1C4 VA: 0x9BD1C4
	public bool get_ignoreParent() { }

	// RVA: 0x9BD1CC Offset: 0x9BD1CC VA: 0x9BD1CC
	public void set_ignoreParent(bool value) { }

	// RVA: 0x9BD1F8 Offset: 0x9BD1F8 VA: 0x9BD1F8
	public bool get_isRoot() { }

	// RVA: 0x9BD278 Offset: 0x9BD278 VA: 0x9BD278 Slot: 24
	public override bool get_raycastTarget() { }

	// RVA: 0x9BD280 Offset: 0x9BD280 VA: 0x9BD280 Slot: 25
	public override void set_raycastTarget(bool value) { }

	// RVA: 0x9BCE08 Offset: 0x9BCE08 VA: 0x9BCE08
	public ParticleSystem get_cachedParticleSystem() { }

	// RVA: 0x9BD288 Offset: 0x9BD288 VA: 0x9BD288 Slot: 58
	public override Material GetModifiedMaterial(Material baseMaterial) { }

	// RVA: 0x9BD3AC Offset: 0x9BD3AC VA: 0x9BD3AC Slot: 5
	protected override void OnEnable() { }

	// RVA: 0x9BDCF4 Offset: 0x9BDCF4 VA: 0x9BDCF4 Slot: 7
	protected override void OnDisable() { }

	// RVA: 0x9BE318 Offset: 0x9BE318 VA: 0x9BE318 Slot: 41
	protected override void UpdateGeometry() { }

	// RVA: 0x9BE31C Offset: 0x9BE31C VA: 0x9BE31C Slot: 12
	protected override void OnTransformParentChanged() { }

	// RVA: 0x9BE4B0 Offset: 0x9BE4B0 VA: 0x9BE4B0 Slot: 13
	protected override void OnDidApplyAnimationProperties() { }

	// RVA: 0x9BE4B4 Offset: 0x9BE4B4 VA: 0x9BE4B4
	private static void UpdateMeshes() { }

	// RVA: 0x9BE67C Offset: 0x9BE67C VA: 0x9BE67C
	private void UpdateMesh() { }

	// RVA: 0x9BD92C Offset: 0x9BD92C VA: 0x9BD92C
	private void CheckTrail() { }

	// RVA: 0x9BDF5C Offset: 0x9BDF5C VA: 0x9BDF5C
	private void SetParent(UIParticle newParent) { }

	// RVA: 0x9C0194 Offset: 0x9C0194 VA: 0x9C0194
	private void UpdateAnimatableMaterialProperties() { }

	// RVA: 0x9C05E0 Offset: 0x9C05E0 VA: 0x9C05E0
	public void .ctor() { }

	// RVA: 0x9C06A4 Offset: 0x9C06A4 VA: 0x9C06A4
	private static void .cctor() { }
}

// Namespace: Coffee.UIExtensions
[AddComponentMenu] // RVA: 0x36FC20 Offset: 0x36FC20 VA: 0x36FC20
[ExecuteInEditMode] // RVA: 0x36FC20 Offset: 0x36FC20 VA: 0x36FC20
public class UIParticleOverlayCamera : MonoBehaviour // TypeDefIndex: 12030
{
	// Fields
	private Camera m_Camera; // 0xC
	private static UIParticleOverlayCamera s_Instance; // 0x0

	// Properties
	public static UIParticleOverlayCamera instance { get; }
	private Camera cameraForOvrelay { get; }

	// Methods

	// RVA: 0x9C089C Offset: 0x9C089C VA: 0x9C089C
	public static UIParticleOverlayCamera get_instance() { }

	// RVA: 0x9BFF7C Offset: 0x9BFF7C VA: 0x9BFF7C
	public static Camera GetCameraForOvrelay(Canvas canvas) { }

	// RVA: 0x9C0B74 Offset: 0x9C0B74 VA: 0x9C0B74
	private Camera get_cameraForOvrelay() { }

	// RVA: 0x9C0CAC Offset: 0x9C0CAC VA: 0x9C0CAC
	private void Awake() { }

	// RVA: 0x9C0FD4 Offset: 0x9C0FD4 VA: 0x9C0FD4
	private void OnEnable() { }

	// RVA: 0x9C1078 Offset: 0x9C1078 VA: 0x9C1078
	private void OnDestroy() { }

	// RVA: 0x9C1130 Offset: 0x9C1130 VA: 0x9C1130
	public void .ctor() { }
}

// Namespace: 
private struct <PrivateImplementationDetails>.__StaticArrayInitTypeSize=12 // TypeDefIndex: 12031
{}

// Namespace: 
private struct <PrivateImplementationDetails>.__StaticArrayInitTypeSize=32 // TypeDefIndex: 12032
{}

// Namespace: 
private struct <PrivateImplementationDetails>.__StaticArrayInitTypeSize=68 // TypeDefIndex: 12033
{}

// Namespace: 
private struct <PrivateImplementationDetails>.__StaticArrayInitTypeSize=84 // TypeDefIndex: 12034
{}

// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x36FC68 Offset: 0x36FC68 VA: 0x36FC68
internal sealed class <PrivateImplementationDetails> // TypeDefIndex: 12035
{
	// Fields
	internal static readonly <PrivateImplementationDetails>.__StaticArrayInitTypeSize=32 2EF83B43314F8CD03190EEE30ECCF048DA37791237F27C62A579F23EACE9FD70 /*Metadata offset 0x4C4C6A*/; // 0x0
	internal static readonly <PrivateImplementationDetails>.__StaticArrayInitTypeSize=12 5500CD4935AA7AD89125EB7856CA60D99B18862314BBA925F33E55A70DEF45C0 /*Metadata offset 0x4C4C8A*/; // 0x20
	internal static readonly <PrivateImplementationDetails>.__StaticArrayInitTypeSize=84 98E585698F789423A98817D48E257C8D19F9409CB425A7D52834D0C4109AC71E /*Metadata offset 0x4C4C96*/; // 0x2C
	internal static readonly <PrivateImplementationDetails>.__StaticArrayInitTypeSize=32 A11524E59E0A80B36A6D06F0B46E5B3A5D8CA685FD63CAEF597D778B72CAFACD /*Metadata offset 0x4C4CEA*/; // 0x80
	internal static readonly <PrivateImplementationDetails>.__StaticArrayInitTypeSize=12 E2E455BF79966D9B140422A285968F982178EA03A2594732DFCF7FE80F8CF2C8 /*Metadata offset 0x4C4D0A*/; // 0xA0
	internal static readonly <PrivateImplementationDetails>.__StaticArrayInitTypeSize=68 FB1BF14FF9D4E0C2E61779E6DCD4A65DAED6EA62BF72F0DA2708BD3523EC3D9D /*Metadata offset 0x4C4D16*/; // 0xAC

	// Methods

	// RVA: 0x99BC80 Offset: 0x99BC80 VA: 0x99BC80
	internal static uint ComputeStringHash(string s) { }
}
