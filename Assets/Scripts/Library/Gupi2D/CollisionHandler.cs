using UnityEngine;
using UnityEngine.Events;

namespace Gupi2D
{
	[RequireComponent(typeof(Collider2D))]
	public class CollisionHandler : MonoBehaviour
	{
		[SerializeField]
		private string[] _tagsToCheckWith;

		[Space(20f)]

		[SerializeField]
		private bool _autoDestroyThis = false;

		[SerializeField]
		private bool _autoDestroyCollided = false;

		[Space(5f)]

		[Header("Action/s Upon Collision")]
		[SerializeField] private UnityEvent _onCollisionEnter;
		[SerializeField] private UnityEvent _onCollisionExit;

		private int _tagsCount;

		private void Awake()
		{
			_tagsCount = _tagsToCheckWith.Length;
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (!TagRegistered(collision.gameObject.tag)) return;

			_onCollisionEnter.Invoke();

			if (_autoDestroyCollided)
			{
				Destroy(collision.gameObject);
			}

			if (_autoDestroyThis)
			{
				Destroy(gameObject);
			}
		}

		private void OnCollisionExit2D(Collision2D collision)
		{
			if (!TagRegistered(collision.gameObject.tag)) return;

			_onCollisionExit.Invoke();
		}

		private bool TagRegistered(string tag)
		{
			if (string.IsNullOrEmpty(tag)) return false;

			for (int i = 0; i < _tagsCount; i++)
			{
				if (_tagsToCheckWith[i] == tag) return true;
			}

			return false;
		}
	}
}
