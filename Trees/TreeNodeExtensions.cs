namespace Trees;

public static class TreeNodeExtensions
{
	public static TreeNode<T> GetTree<T>(this T?[] list) where T : struct => GetTreeNode(list, 0);

	private static TreeNode<T> GetTreeNode<T>(T?[] list, int i) where T : struct =>
		i < list.Length && list[i].HasValue
			? new(
				val: list[i].Value,
				left: GetTreeNode(list, (i * 2) + 1),
				right: GetTreeNode(list, (i * 2) + 2))
			: null;
}