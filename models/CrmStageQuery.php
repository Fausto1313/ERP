<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[CrmStage]].
 *
 * @see CrmStage
 */
class CrmStageQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return CrmStage[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return CrmStage|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}
