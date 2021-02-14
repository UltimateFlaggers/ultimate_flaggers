using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public interface IAttackEvent
{
	void AttackFunction(GameObject playerObject);

	int GetAttackFrame();
}
