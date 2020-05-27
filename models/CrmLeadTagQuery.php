<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[CrmLeadTag]].
 *
 * @see CrmLeadTag
 */
class CrmLeadTagQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return CrmLeadTag[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return CrmLeadTag|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}
