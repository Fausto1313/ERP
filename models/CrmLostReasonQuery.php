<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[CrmLostReason]].
 *
 * @see CrmLostReason
 */
class CrmLostReasonQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return CrmLostReason[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return CrmLostReason|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}
