public interface IHealthGUI {
	void Setup(IHealth health);
	void OnHealthChanges(object sender, System.EventArgs e);
}