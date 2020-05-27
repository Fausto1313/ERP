<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[CrmTeam]].
 *
 * @see CrmTeam
 */
class CrmTeamQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return CrmTeam[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return CrmTeam|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}
